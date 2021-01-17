using DashAgil.Integrador.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Integrador.Commands.Input
{
    public class SalvarEstoriaCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(this.Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(this.Descricao, "Descricao", "Descricao é obrigatório")
            );

            return Valid;
        }
    }
}
