using DashAgil.Integrador.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Integrador.Commands.Input
{
    public class AtualizarTiposWorkItens : Notifiable, ICommandPadrao
    {
        public string Organizacao { get; set; }
        public string Projeto { get; set; }
        public string Time { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(this.Organizacao, "Organizacao", "Organizacao é obrigatório")
               .IsNotNullOrEmpty(this.Projeto, "Projeto", "Projeto é obrigatório")
               .IsNotNullOrEmpty(this.Time, "Time", "Time é obrigatório")
               .IsTrue(ValidarOrganizazcao(Organizacao), "Organizacao", "Organizacao não válida")
           );

            return Valid;
        }

        internal bool ValidarOrganizazcao(string organizacao) => organizacao != null && organizacao == "Rendimento" || organizacao == "Corporativo";
    }
}
