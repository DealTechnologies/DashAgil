using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input.VisaoGeral
{
    public class ObterVelocidadePorSquadCommand : Notifiable, ICommandPadrao
    {
        public string IdCliente { get; set; }
        public string IdSquad { get; set; }
        public string IdUsuario { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(IdCliente, "IdCliente", "Id do cliente é obrigatório")
                .IsNotNullOrEmpty(IdSquad, "IdSquad", "Id da squad é obrigatório")
                .IsNotNullOrEmpty(IdUsuario, "IdUsuario", "Id do usuário é obrigatório")
            );

            return Valid;
        }
    }
}

