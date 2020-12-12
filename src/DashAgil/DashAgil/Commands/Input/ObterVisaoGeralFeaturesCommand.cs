using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input
{
    public class ObterVisaoGeralFeaturesCommand : Notifiable, ICommandPadrao
    {
        public string IdProjeto { get; set; }
        public string IdSquad { get; set; }
        public string IdSprint { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(IdProjeto, "IdProjeto", "Id do projeto é obrigatório")
                .IsNotNullOrEmpty(IdProjeto, "IdSquad", "Id da squad é obrigatória")
                .IsNotNullOrEmpty(IdSprint, "IdSprint", "Id da sprint é obrigatória")
            );

            return Valid;
        }
    }
}
