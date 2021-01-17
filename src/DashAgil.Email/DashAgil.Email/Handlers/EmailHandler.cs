using Amazon.SimpleEmail.Model;
using Amazon.SimpleNotificationService.Util;
using DashAgil.Commands.Input;
using DashAgil.Commands.Output;
using DashAgil.Email.Commands.Input;
using DashAgil.Email.Infra.Helper;
using DashAgil.Email.Repositorio;
using DashAgil.Entidades;
using DashAgil.Infra.Comum;
using Flunt.Notifications;
using MimeKit;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class EmailHandler : Notifiable, ICommandHandler<EnviarEmailCommand>, ICommandHandler<ReceiveNotificationCommand>
    {
        private readonly ISesRepositorio sesRepositorio;

        private readonly IEmailRepositorio emailRepositorio;

        public EmailHandler(ISesRepositorio sesRepositorio, IEmailRepositorio emailRepositorio)
        {
            this.sesRepositorio = sesRepositorio;
            this.emailRepositorio = emailRepositorio;
        }

        public async Task<ICommandResult> Handle(EnviarEmailCommand command)
        {
            command.EhValido();
            command.AddNotifications(command.Notifications);

            if (Invalid)
            {
                return new DashAgilCommandResult(false, "failed", Notifications);
            }

            //command.NomeRemetente = "DashAgil";
            //command.Destinatarios = new List<string> { "luciano93p@gmail.com" };

            var email = NewRawEmail(command);
            var response = await this.sesRepositorio.SendRawEmailAsync(email);

            #region SendEmailAsync sample
            ////var response = await this.sesRepositorio.SendEmailAsync(new SendEmailRequest
            ////{
            ////    Destination = new Destination { ToAddresses = command.Destinatarios },
            ////    Message = new Amazon.SimpleEmail.Model.Message
            ////    {
            ////        Subject = new Content { Data = command.Assunto },
            ////        Body = new Body { Text = new Content { Data = command.Conteudo } }
            ////    },
            ////    Source = remetente
            ////});
            #endregion

            await this.emailRepositorio.AdicionarAsync(new Emails
            {
                Id = Utils.ParseToGuid(response.MessageId).Value,
                Assunto = command.Assunto,
                Conteudo = command.Conteudo,
                Anexos = null,
                DataCriacao = DateTime.Now,
                NomeRemetente = command.NomeRemetente,
                Remetente = sesRepositorio.FromAddress,
                Destinatario = JsonSerializer.Serialize(command.Destinatarios),
                Status = StatusEmail.Created
            });

            return new DashAgilCommandResult(true, "sucess", response);
        }

        public async Task<ICommandResult> Handle(ReceiveNotificationCommand command)
        {
            command.EhValido();
            AddNotifications(command.Notifications);

            if (Invalid)
            {
                return new DashAgilCommandResult(false, "response is null", false);
            }

            if (command.Message.Type == Amazon.SimpleNotificationService.Util.Message.MESSAGE_TYPE_SUBSCRIPTION_CONFIRMATION && !string.IsNullOrEmpty(command.Message.SubscribeURL))
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

                var response = await client.GetAsync(command.Message.SubscribeURL);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return new DashAgilCommandResult(
                        true,
                        response?.ReasonPhrase,
                        System.Text.Json.JsonSerializer.Deserialize<dynamic>(content, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                        response.StatusCode
                    );
                }

                return new DashAgilCommandResult(
                       false,
                       response?.ReasonPhrase,
                       null
                   );
            }

            if (!string.IsNullOrEmpty(command.Message.MessageText))
            {
                var messageText = JsonDocument.Parse(command.Message.MessageText).RootElement;
                var emailId = Utils.ParseToGuid(messageText.GetProperty("mail").GetProperty("messageId").ToString()) ?? Guid.Empty;

                var email = await emailRepositorio.ObterAsync(emailId);
                if (email != null)
                {
                    Enum.TryParse(messageText.GetProperty("eventType").ToString(), out StatusEmail statusEmail);

                    email.Status = statusEmail;

                    switch (email.Status)
                    {
                        case StatusEmail.Send:
                            email.DataEnvio = DateTime.Parse(messageText.GetProperty("mail").GetProperty("timestamp").ToString());
                            break;
                        case StatusEmail.Delivery:

                            var recipientArray = new JArray();
                            if (email.Entregues != null)
                            {
                                recipientArray = JArray.Parse(email.Entregues);
                            }

                            recipientArray.Add(new JObject
                                {
                                    new JProperty("deliveryDate", messageText.GetProperty("delivery").GetProperty("timestamp").ToString()),
                                    new JProperty("recipient", messageText.GetProperty("delivery").GetProperty("recipients").ToString()),
                                });

                            email.Entregues = recipientArray != null ? recipientArray.ToString() : null;
                            break;
                        case StatusEmail.Complaint:

                            //TODO That wasn't tested.
                            var complaintArray = new JArray();
                            if (email.ComplainedRecipients != null)
                            {
                                complaintArray = JArray.Parse(email.ComplainedRecipients);
                            }

                            foreach (var complaints in messageText.GetProperty("complaint").GetProperty("complainedRecipients").EnumerateArray())
                            {
                                complaintArray.Add(new JObject
                                    {
                                        new JProperty("complainedDate", messageText.GetProperty("complaint").GetProperty("arrivalDate").ToString()),
                                        new JProperty("emailAddress", complaints.GetProperty("emailAddress"))
                                    });
                            }

                            email.ComplainedRecipients = complaintArray != null ? complaintArray.ToString() : null;
                            break;
                        case StatusEmail.Bounce:

                            var bounceArray = new JArray();
                            if (email.Lixo != null)
                            {
                                bounceArray = JArray.Parse(email.Lixo);
                            }

                            foreach (var recipients in messageText.GetProperty("bounce").GetProperty("bouncedRecipients").EnumerateArray())
                            {
                                bounceArray.Add(new JObject
                                    {
                                        new JProperty("bouncedDate", messageText.GetProperty("bounce").GetProperty("timestamp").ToString()),
                                        new JProperty("emailAddress", recipients.GetProperty("emailAddress")),
                                        new JProperty("action", recipients.GetProperty("action"))
                                    });
                            }

                            email.Lixo = bounceArray != null ? bounceArray.ToString() : null;
                            break;
                        case StatusEmail.Open:

                            var openArray = new JArray();
                            if (email.Abertos != null)
                            {
                                openArray = JArray.Parse(email.Abertos);
                            }

                            openArray.Add(new JObject
                                {
                                    new JProperty("openDate", messageText.GetProperty("open").GetProperty("timestamp").ToString()),
                                    new JProperty("idAddress", messageText.GetProperty("open").GetProperty("ipAddress").ToString()),
                                    new JProperty("userAgend", messageText.GetProperty("open").GetProperty("userAgent").ToString()),
                                });

                            email.Abertos = openArray != null ? openArray.ToString() : null;

                            break;
                        case StatusEmail.Click:
                            break;
                        default:
                            break;
                    }

                    await emailRepositorio.AtualizarAsync(email);

                    return new DashAgilCommandResult(
                       true,
                       "recieved",
                       null
                   );
                }
            }

            return new DashAgilCommandResult(
                   false,
                   "error",
                   null
               );
        }

        private SendRawEmailRequest NewRawEmail(EnviarEmailCommand command)
        {
            var body = new BodyBuilder
            {
                HtmlBody = command.Conteudo
            };

            //email.FilePaths?.ToList().ForEach(o =>
            //{
            //    var (name, content) = GetFiles(o);
            //    body.Attachments.Add(name, content);
            //});

            var message = new MimeMessage
            {
                Subject = command.Assunto,
                Body = body.ToMessageBody()
            };

            message.From.Add(new MailboxAddress(command.NomeRemetente, new List<string> { "" }, this.sesRepositorio.FromAddress));
            command.Destinatarios.ForEach(destinatario =>
            {
                message.To.Add(new MailboxAddress("", destinatario));
            });

            var stream = new MemoryStream();
            message.WriteTo(stream);

            return new SendRawEmailRequest
            {
                RawMessage = new RawMessage(stream),
                ConfigurationSetName = this.sesRepositorio.ConfigurationSetsName
            };
        }
    }
}
