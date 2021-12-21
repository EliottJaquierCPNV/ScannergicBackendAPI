using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ScannergicAPI.Repositories
{
    public class AllergenRequester
    {
        private DBConnector dBConnector;
        private MySqlDataReader dataReader;
        public AllergenRequester()
        {
            Initialize();
        }
        private void Initialize()
        {
            dBConnector = new DBConnector();
        }
        public List<List<string>> GetPlainAllergensInDB()
        {
            string query = "SELECT * FROM allergen;";
            dataReader = dBConnector.Select(query);
            return FormatResultForPlainAllergen(dataReader);
        }
        private List<List<string>> FormatResultForPlainAllergen(MySqlDataReader dataReader)
        {
            List<List<string>> datas = new List<List<string>>(); 
            while (dataReader.Read())
            {
                datas.Add(
                    new List<string>()
                    {
                        dataReader.GetString(0),
                        dataReader.GetString(1)
                    }
                );
            }
            
            return datas;
        }
    }
    public class AlergenRequesterException : Exception { }
}
