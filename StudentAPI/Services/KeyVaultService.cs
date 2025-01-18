using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace StudentAPI.Services
{
    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(string keyVaultUri)
        {
            var credential = new DefaultAzureCredential();
            _secretClient = new SecretClient(new Uri(keyVaultUri), credential);
        }

        public string GetConnectionString(string secretName)
        {
            // Retrieve the secret from Key Vault
            KeyVaultSecret secret = _secretClient.GetSecret(secretName);
            return secret.Value;
        }
    }
}
