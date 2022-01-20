using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
        /// A list of lists of string containing selected datas
        /// </returns>
        public List<List<string>> Select(string query)
        {
            //Open connection
            OpenConnection();
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //close Connection
            List<List<string>> datas = new List<List<string>>();

            while (dataReader.Read())
            {
                List<string> tempList = new();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    tempList.Add(dataReader.GetValue(i).ToString());
                }

                datas.Add(tempList);
            }
            CloseConnection();

            return datas;
        }

    }
}
