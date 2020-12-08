using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;

namespace DashAgil.Commands.Input
{
    public class ObterVisaoEstoriasPorSquadCommand : Notifiable, ICommandPadrao
    {
        public string IdProjeto { get; set; }        

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(IdProjeto, "IdProjeto", "Id do projeto é obrigatório")          
            );

            return Valid;
        }
    }
}
