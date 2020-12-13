using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input.Cliente
{
    public class ObterClientesPorProvedorCommand : Notifiable, ICommandPadrao
    {
        public string IdProvedor { get; set; }
        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(IdProvedor, "IdProvedor", "Id do provedor é obrigatório")
            );

            return Valid;
        }
    }
}
