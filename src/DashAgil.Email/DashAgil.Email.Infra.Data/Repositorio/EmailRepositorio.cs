using Amazon.SimpleEmail.Model;
using DashAgil.Email.Infra.Data.Context;
using DashAgil.Email.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Email.Infra.Data.Repositorio
{
    public class EmailRepositorio : IEmailRepositorio
    {
        private readonly AwsContext context;

        public EmailRepositorio(AwsContext context)
        {
            this.context = context;
        }

        public async Task<SendEmailResponse> SendEmailAsync(SendEmailRequest emailRequest) =>
            await context.client.SendEmailAsync(emailRequest);

        public async Task<SendRawEmailResponse> SendRawEmailAsync(SendRawEmailRequest emailRequest) =>
            await context.client.SendRawEmailAsync(emailRequest);
    }
}
