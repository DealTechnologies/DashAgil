using DashAgil.Integrador.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Integrador.Jira.Commands.Input.Integrador
{
    public class IntegracaoInicialJiraCommand : Notifiable, ICommandPadrao
    {
        public string Url { get; set; }

        public string Token { get; set; }
        public int OrganizacaoId { get; set; }
        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Url, "Url", "Url deve ser preenchida")
                .IsNotNullOrEmpty(Token, "Token", "Token deve ser preenchido"));

            return Valid;
        }
    }
}
