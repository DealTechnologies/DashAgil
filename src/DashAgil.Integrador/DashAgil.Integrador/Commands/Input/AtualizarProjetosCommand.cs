using DashAgil.Integrador.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Integrador.Commands.Input
{
    public class AtualizarProjetosCommand : Notifiable, ICommandPadrao
    {
        public string Organizacao { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(this.Organizacao, "Organizacao", "Organizacao é obrigatório") 
               .IsTrue(ValidarOrganizazcao(Organizacao), "Organizacao", "Organizacao não válida")
           );

            return Valid;
        }

        internal bool ValidarOrganizazcao(string organizacao) => organizacao != null && organizacao == "Rendimento" || organizacao == "Corporativo";
    }
}
