using MySql.Data.MySqlClient;

namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Allow a DB connection and CRUD requests such as SELECT, UPDATE, INSERT, DELETE
    /// WARNING ! For the moment only SELECT function is correctly implemented, other are private methods for security purposes
    /// </summary>
    public class DBConnector
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnector()
        {
            Initialize();
        }

        /// <summary>
        /// Get credentials and creates connection string. Does it when initializing new DBConnector object
        /// </summary>
        private void Initialize()
        {
            CredentialReader credentialReader = new("credentials.json");
            server = credentialReader.Credentials.Server;
            database = credentialReader.Credentials.Database;
            uid = credentialReader.Credentials.Username;
            password = credentialReader.Credentials.Password;
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Opens connection to DB
        /// </summary>
        private void OpenConnection()
        {
                connection.Open();
        }

        /// <summary>
        /// Close connection to DB
        /// </summary>
        private void CloseConnection()
        {
                connection.Close();
        }

        /// <summary>
        /// Executes SELECT statement and returns query result
        /// </summary>
        /// <param name="query">SELECT query to execute</param>
        /// <returns>
        /// MysqlDataReader object, allowing to select the needed datas depending on the data type
        /// </returns>
        public MySqlDataReader Select(string query)
        {
            //Open connection
            OpenConnection();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //close Connection
            // TODO - To allow connection to close without loosing datas,
            // you need to extract to datas out of the datareader in a list.
            // Datareader should only be used in this file and not in upper layer files
            //CloseConnection();

            //Return datas
            return dataReader;
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="query"></param>
        private void Insert(string query)
        {
            //open db connection
            OpenConnection();

            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            CloseConnection();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="query"></param>
        private void Update(string query)
        {

            //Open connection
            OpenConnection();
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            CloseConnection();
        }

        /// <summary>
        /// Not implemented yet
        /// </summary>
        /// <param name="query"></param>
        private void Delete(string query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
