using System;

namespace DashAgil.Entidades
{
    /// <summary>
    /// Email enum.
    /// </summary>
    public enum StatusEmail
    {
        Created,
        Send,
        Delivery,
        Complaint,
        Reject,
        Bounce,
        Open,
        Click
    }

    /// <summary>
    /// The email entity class.
    /// </summary>
    public class Emails
    {
        /// <summary>
        /// Gets or sets the guid.
        /// </summary>
        /// <value>The guid.</value>
        public Guid Id { get; set; }

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
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        public string Anexos { get; set; }

        /// <summary>
        /// Gets or sets the source name.
        /// </summary>
        /// <value>The source name.</value>
        public string NomeRemetente { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string Remetente { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>The destination.</value>
        public string Destinatario { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Gets or sets the send date.
        /// </summary>
        /// <value>The send date.</value>
        public DateTime? DataEnvio { get; set; }

        /// <summary>
        /// Gets or sets the delivered recipients.
        /// </summary>
        /// <value>The delivered recipients.</value>
        public string Entregues { get; set; }

        /// <summary>
        /// Gets or sets the bounced recipients.
        /// </summary>
        /// <value>The bonced recipients.</value>
        public string Lixo { get; set; }

        /// <summary>
        /// Gets or sets the complained recipients.
        /// </summary>
        /// <value>The complained recpipients.</value>
        public string ComplainedRecipients { get; set; }

        /// <summary>
        /// Gets or sets the rejected recipients.
        /// </summary>
        /// <value>The rejected recipients.</value>
        public string Rejeitados { get; set; }

        /// <summary>
        /// Gets or sets the opened recipients.
        /// </summary>
        /// <value>The openend recipients.</value>
        public string Abertos { get; set; }

        /// <summary>
        /// Gets or sets the email status.
        /// </summary>
        /// <value>The email status.</value>
        public StatusEmail Status { get; set; }
    }
}
