using DashAgil.Commands.Input;
using DashAgil.Commands.Output;
using DashAgil.Infra.Comum;
using DashAgil.Repositorio;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace DashAgil.Handlers
{
    public class AuthHandler : Notifiable, ICommandHandler<AuthCommand>
    {
        private readonly IUsuarioRepository usuarioSquadsRepository;

        public AuthHandler(IUsuarioRepository usuarioSquadsRepository)
        {
            this.usuarioSquadsRepository = usuarioSquadsRepository;
        }

        public async Task<ICommandResult> Handle(AuthCommand command)
        {
            command.EhValido();
            AddNotifications(command.Notifications);

            if (Invalid)
            {
                new DashAgilCommandResult(false, "auth failed", Notifications);
            }

            var usuario = await usuarioSquadsRepository.ObterAsync(command.Username, command.Password);
            if (usuario == null)
            {
                return new DashAgilCommandResult(false, "auth failed", usuario);
            }

            var acessos = await usuarioSquadsRepository.ObterAcessosAsync(usuario.Id);

            return new DashAgilCommandResult(true, "success", acessos);
        }
    }
}
