using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input
{
    public class SalvarEstoriaCommand : Notifiable, ICommandPadrao
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, "Nome", "Nome é obrigatório")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Descricao é obrigatório")
            );

            return Valid;
        }
    }
}
