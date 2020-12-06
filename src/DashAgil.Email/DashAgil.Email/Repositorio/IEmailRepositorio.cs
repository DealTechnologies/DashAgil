using Amazon.SimpleEmail.Model;
using System.Threading.Tasks;

namespace DashAgil.Email.Repositorio
{
    public interface IEmailRepositorio
    {
        Task<SendEmailResponse> SendEmailAsync(SendEmailRequest emailRequest);

        Task<SendRawEmailResponse> SendRawEmailAsync(SendRawEmailRequest emailRequest);
    }
}
