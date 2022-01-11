//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MySql.Data.MySqlClient;

//namespace ScannergicAPI.Repositories
//{
//    /// <summary>
//    /// Requests the specific datas needed for the allergens directly to a DBConnector object
//    /// </summary>
//    public class AllergenRequester
//    {
//        private DBConnector dBConnector;
//        public AllergenRequester()
//        {
//            Initialize();
//        }
//        /// <summary>
//        /// creates new DBConnector object
//        /// </summary>
//        private void Initialize()
//        {
//            dBConnector = new DBConnector();
//        }
//        /// <summary>
//        /// Creates query and sends it to DBConnnector.
//        /// </summary>
//        /// <returns>Formatted datas; List of Lists of string</returns>
//        public List<List<string>> GetPlainAllergensInDB()
//        {
//            string query = "SELECT * FROM allergen;";
//            dataReader = dBConnector.Select(query);
//            return FormatResultForPlainAllergen(dataReader);
//        }
//        /// <summary>
//        /// Reads datas from data reader and returns formatted datas
//        /// </summary>
//        /// <param name="dataReader"></param>
//        /// <returns>Formatted datas</returns>
//        private List<List<string>> FormatResultForPlainAllergen(MySqlDataReader dataReader)
//        {
//            List<List<string>> datas = new List<List<string>>(); 
//            while (dataReader.Read())
//            {
//                datas.Add(
//                    new List<string>()
//                    {
//                        dataReader.GetString(0),
//                        dataReader.GetString(1)
//                    }
//                );
//            }
//            return datas;
//        }
//    }
//}
