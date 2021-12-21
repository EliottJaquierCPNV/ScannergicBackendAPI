using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScannergicAPI.Repositories
{
    public class DBConnector
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnector()
        {
            Initialize();
        }

        //Initialize values
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

        //open connection to database
        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                switch (ex.Code)
                {
                    case 0:
                        throw new UnableToConnectToTheServer();

                    case 1045:
                        throw new AccessDeniedToDB();
                }
            }
        }

        //Close connection
        private void CloseConnection()
        {
                connection.Close();
        }

        //Select statement
        public MySqlDataReader Select(string query)
        {
            //Open connection
            OpenConnection();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //close Connection
            // TODO - Find a way to close connection after reading datas
            //CloseConnection();

            //Return datas
            return dataReader;
        }

        //Insert statement
        public void Insert(string query)
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

        //Update statement
        public void Update(string query)
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

        //Delete statement
        public void Delete(string query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
}
    public class CredentialReader
    {
        private string credFilePath, text;
        private DBCredential dBCreds;

        public CredentialReader(string credentialFilePath)
        {
            credFilePath = credentialFilePath;
            GetCredentials();
        }

        private void GetCredentials()
        {
            text = System.IO.File.ReadAllText(credFilePath);
            dBCreds = JsonSerializer.Deserialize<DBCredential>(text);
        }
        public DBCredential Credentials { get => dBCreds; }

    }
    public class DBCredential
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Server { get; set; }
    }
    public class DBConnectorException : Exception { }
    public class UnableToConnectToTheServer : DBConnectorException { }
    public class AccessDeniedToDB : DBConnectorException { }
}
