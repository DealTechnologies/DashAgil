using Amazon.SimpleNotificationService.Util;
using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Email.Commands.Input
{
    public class ReceiveNotificationCommand : Notifiable, ICommandPadrao
    {
        public Message Message { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNull(Message, "Message deve ser preenchido.", "Message deve ser preenchido.")
            );

            return Valid;
        }
    }
}
