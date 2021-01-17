using Amazon.SimpleEmail.Model;
using DashAgil.Email.Infra.Data.Context;
using DashAgil.Email.Repositorio;
using System.Threading.Tasks;

namespace DashAgil.Email.Infra.Data.Repositorio
{
    public class SesRepositorio : ISesRepositorio
    {
        private readonly AwsContext context;

        public SesRepositorio(AwsContext context)
        {
            this.context = context;
            this.FromAddress = context.FromAddress;
            this.ConfigurationSetsName = context.ConfigurationSetsName;
        }

        public string FromAddress { get; }

        public string ConfigurationSetsName { get; }

        public async Task<SendEmailResponse> SendEmailAsync(SendEmailRequest emailRequest) =>
            await context.client.SendEmailAsync(emailRequest);

        public async Task<SendRawEmailResponse> SendRawEmailAsync(SendRawEmailRequest emailRequest) =>
            await context.client.SendRawEmailAsync(emailRequest);
    }
}
