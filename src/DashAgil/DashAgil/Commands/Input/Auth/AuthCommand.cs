using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input
{
    public class AuthCommand : Notifiable, ICommandPadrao
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(this.Email, "Email é obrigatório.", "Email é obrigatório.")
                .IsNotNullOrEmpty(this.Password, "Password é obrigatório.", "Password é obrigatório.")
            );

            return Valid;
        }
    }
}
