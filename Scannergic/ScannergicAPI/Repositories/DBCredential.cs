namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Stores credentials for DB connection
    /// </summary>
    public class DBCredential
    {
        /// <summary>
        /// Username is the username for the app DB user
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password is the password of the app DB user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Database is the name of the app database
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// Server is the IP address or FQDN of the app DB server
        /// </summary>
        public string Server { get; set; }
    }
}
