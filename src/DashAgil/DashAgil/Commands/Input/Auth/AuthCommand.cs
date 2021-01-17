using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input
{
    public class AuthCommand : Notifiable, ICommandPadrao
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(this.Username, "Username é obrigatório.", "Username é obrigatório.")
                .IsNotNullOrEmpty(this.Password, "Password é obrigatório.", "Password é obrigatório.")
            );

            return Valid;
        }
    }
}
