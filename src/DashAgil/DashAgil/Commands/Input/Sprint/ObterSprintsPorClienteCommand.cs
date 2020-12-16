using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input.Sprint
{
    public class ObterSprintsPorClienteCommand : Notifiable, ICommandPadrao
    {
        public string IdCliente { get; set; }
        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(IdCliente, "IdCliente", "Id do cliente é obrigatório")
            );

            return Valid;
        }
    }
}
