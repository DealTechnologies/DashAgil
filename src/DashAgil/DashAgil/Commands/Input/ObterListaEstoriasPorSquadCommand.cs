using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input
{
    public class ObterListaEstoriasPorSquadCommand : Notifiable, ICommandPadrao
    {
        public string IdProjeto { get; set; }
        public string IdSquad { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(IdProjeto, "IdProjeto", "Id do projeto é obrigatório")
                .IsNotNullOrEmpty(IdSquad, "IdSquad", "Id da squad é obrigatória")                
            );

            return Valid;
        }
    }
}
