using Amazon.SimpleEmail.Model;
using DashAgil.Commands.Input;
using DashAgil.Commands.Output;
using DashAgil.Email.Repositorio;
using DashAgil.Infra.Comum;
using MimeKit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class EmailHandler : ICommandHandler<EnviarEmailCommand>
    {
        private readonly IEmailRepositorio emailRepositorio;

        public EmailHandler(IEmailRepositorio emailRepositorio)
        {
            this.emailRepositorio = emailRepositorio;
        }

        public async Task<ICommandResult> Handle(EnviarEmailCommand command)
        {
            //var stream = new MemoryStream();
            //message.WriteTo(stream);

            //var rawMessage = new Amazon.SimpleEmail.Model.RawMessage();            

            var emailRequest = NewRawEmail(command);

            var response = await this.emailRepositorio.SendRawEmailAsync(emailRequest);

            //var reponse = await this.emailRepositorio.SendEmailAsync(new Amazon.SimpleEmail.Model.SendEmailRequest
            //{
            //    Destination = new Amazon.SimpleEmail.Model.Destination { ToAddresses = new System.Collections.Generic.List<string> { "ls.henrique@outlook.com" } },
            //    Message = new Amazon.SimpleEmail.Model.Message
            //    {
            //        Subject = new Amazon.SimpleEmail.Model.Content { Data = "SES!" },
            //        Body = new Amazon.SimpleEmail.Model.Body { Text = new Amazon.SimpleEmail.Model.Content { Data = "Hello SES!" } }
            //    },
            //    Source = "luciano-93p@hotmail.com"
            //});

            return new DashAgilCommandResult(true, "sucess", response);
        }

        private SendRawEmailRequest NewRawEmail(EnviarEmailCommand email)
        {
            var body = new BodyBuilder
            {
                HtmlBody = email.Content
            };

            //email.FilePaths?.ToList().ForEach(o =>
            //{
            //    var (name, content) = GetFiles(o);
            //    body.Attachments.Add(name, content);
            //});


            var message = new MimeMessage
            {
                Subject = email.Subject,
                Body = body.ToMessageBody()
            };

            message.From.Add(new MailboxAddress(new List<string> { email.SourceName }, "luciano-93p@hotmail.com"));
            email.Destination.ForEach(o =>
            {
                message.To.Add(new MailboxAddress(string.Empty, o));
            });


            var stream = new MemoryStream();
            message.WriteTo(stream);


            return new SendRawEmailRequest
            {
                RawMessage = new RawMessage(stream),
                ConfigurationSetName = "SendEmailSES"
            };
        }
    }
}
