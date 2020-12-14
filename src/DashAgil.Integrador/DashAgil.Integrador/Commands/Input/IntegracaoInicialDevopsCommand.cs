using DashAgil.Integrador.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Integrador.Commands.Input
{
    public class IntegracaoInicialDevopsCommand : Notifiable, ICommandPadrao
    {
        public string Organizacao { get; set; }
        public string Token { get; set; } 
        public long ClienteId { get; set; }
        public bool EhValido()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(this.Organizacao, "Organizacao", "Organizacao é obrigatório") 
               .IsNotNullOrEmpty(this.Token, "Token", "Token é obrigatório")
               .IsNotNull(this.ClienteId, "ClienteId", "Cliente é obrigatório")
           );

            return Valid;
        }
         
    }
}
