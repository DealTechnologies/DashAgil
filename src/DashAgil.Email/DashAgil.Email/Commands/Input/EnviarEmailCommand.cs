using DashAgil.Infra.Comum;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace DashAgil.Commands.Input
{
    public class EnviarEmailCommand : Notifiable, ICommandPadrao
    {
        /// <summary>
        /// Gets or sets the source name.
        /// </summary>
        /// <value>The source name.</value>
        public string NomeRemetente { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public List<string> Destinatarios { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Assunto { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Conteudo { get; set; }

        /// <summary>
        /// Gets or sets the file paths.
        /// </summary>
        /// <value>The file paths.</value>
        public IEnumerable<string> AnexoPaths { get; set; }

        public bool EhValido()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(NomeRemetente, "Nome Remetente", "Nome Remetente é obrigatório")
                .IsNotNull(Destinatarios, "Destinatarios", "Destinatarios é obrigatório")
                .IsNotNullOrEmpty(Assunto, "Assunto", "Assunto é obrigatório")
                .IsNotNullOrEmpty(Conteudo, "Conteudo", "Conteudo é obrigatório")
            );

            return Valid;
        }
    }
}
