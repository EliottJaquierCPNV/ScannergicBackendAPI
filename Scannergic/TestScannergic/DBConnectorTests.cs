using NUnit.Framework;
using ScannergicAPI.Repositories;

namespace TestScannergic
{
    public class DBConnectorTests
    {
        [Test]
        public void GetCredentials_GetAllCreds_Success()
        {
            //given
            CredentialReader credentialReader = new("credentials.json");
            DBCredential expectedCredentials = new();
            expectedCredentials.Database = "scannergic";
            expectedCredentials.Server = "localhost";
            expectedCredentials.Username = "root";
            expectedCredentials.Password = "Pa$$w0rd";
            DBCredential actualCredentials;

            //when
            actualCredentials = credentialReader.Credentials;

            //then
            Assert.AreEqual(expectedCredentials.Database, actualCredentials.Database);
            Assert.AreEqual(expectedCredentials.Server, actualCredentials.Server);
            Assert.AreEqual(expectedCredentials.Username, actualCredentials.Username);
            Assert.AreEqual(expectedCredentials.Password, actualCredentials.Password);

        }
    }
}
