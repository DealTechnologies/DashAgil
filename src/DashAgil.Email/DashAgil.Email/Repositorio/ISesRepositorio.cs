using Amazon.SimpleEmail.Model;
using System.Threading.Tasks;

namespace DashAgil.Email.Repositorio
{
    public interface ISesRepositorio
    {
        public string FromAddress { get; }

        public string ConfigurationSetsName { get; }

        Task<SendEmailResponse> SendEmailAsync(SendEmailRequest emailRequest);

        Task<SendRawEmailResponse> SendRawEmailAsync(SendRawEmailRequest emailRequest);
    }
}
