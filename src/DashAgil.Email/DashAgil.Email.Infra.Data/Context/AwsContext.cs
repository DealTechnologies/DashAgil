using Amazon;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using DashAgil.Email.Infra.Data.Settings;
using Microsoft.Extensions.Options;

namespace DashAgil.Email.Infra.Data.Context
{
    public class AwsContext
    {
        private readonly AwsSettings awsSettings;

        private readonly BasicAWSCredentials credentials;

        public readonly AmazonSimpleEmailServiceClient client;

        public AwsContext(IOptions<AwsSettings> options)
        {   
            this.awsSettings = options.Value;
            this.credentials = new BasicAWSCredentials(awsSettings.KeyId, awsSettings.SecretKey);
            this.client = new AmazonSimpleEmailServiceClient(credentials, RegionEndpoint.SAEast1);
        }

        public string FromAddress => awsSettings.FromAddress;

        public string ConfigurationSetsName => awsSettings.ConfigurationSetsName;
    }
}
