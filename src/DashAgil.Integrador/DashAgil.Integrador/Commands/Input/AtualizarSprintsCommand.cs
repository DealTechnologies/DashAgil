using DashAgil.Integrador.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Integrador.Commands.Input
{
    public class AtualizarSprintsCommand : Notifiable, ICommandPadrao
    {
        public long OrganizacaoId { get; set; }
        public string Token { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
               .IsNotNull(this.OrganizacaoId, "Organizacao", "Organizacao é obrigatório")
               .IsNotNullOrEmpty(this.Token, "Token", "Token é obrigatório") 
           );

            return Valid;
        }
    }
}
