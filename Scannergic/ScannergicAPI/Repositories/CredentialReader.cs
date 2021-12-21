using System.Text.Json;

namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Reads credentials for DB in a JSON credentials file
    /// </summary>
    public class CredentialReader
    {
        private string credFilePath, text;
        private DBCredential dBCreds;

        /// <summary>
        /// Constructor : initialize new CredentialReader object
        /// </summary>
        /// <param name="credentialFilePath">Path to the json credentials file</param>
        public CredentialReader(string credentialFilePath)
        {
            credFilePath = credentialFilePath;
            GetCredentials();
        }

        /// <summary>
        /// Private method that reads in credentials file and deserialize the content in a DBCredential object
        /// </summary>
        private void GetCredentials()
        {
            text = System.IO.File.ReadAllText(credFilePath);
            dBCreds = JsonSerializer.Deserialize<DBCredential>(text);
        }

        /// <summary>
        /// Property that returns the credentials
        /// </summary>
        public DBCredential Credentials { get => dBCreds; }
    }
}
