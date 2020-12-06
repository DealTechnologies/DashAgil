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
        public string SourceName { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public List<string> Destination { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the file paths.
        /// </summary>
        /// <value>The file paths.</value>
        public IEnumerable<string> FilePaths { get; set; }

        public bool EhValido()
        {
            //AddNotifications(new Contract()
            //    .IsNotNullOrEmpty(Nome, "Nome", "Nome é obrigatório")
            //    .IsNotNullOrEmpty(Descricao, "Descricao", "Descricao é obrigatório")
            //);

            return Valid;
        }
    }
}
