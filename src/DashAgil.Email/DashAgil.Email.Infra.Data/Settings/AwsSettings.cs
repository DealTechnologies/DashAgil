namespace DashAgil.Email.Infra.Data.Settings
{
    public class AwsSettings
    {
        public string KeyId { get; set; }

        public string SecretKey { get; set; }

        public string FromAddress { get; set; }

        public string ConfigurationSetsName { get; set; }
    }
}
