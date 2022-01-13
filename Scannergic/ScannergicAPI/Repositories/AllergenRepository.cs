using System.Collections.Generic;
using ScannergicAPI.Entities;

namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Is responsible of providing requested Allergen datas
    /// </summary>
    public class AllergenRepository
    {
        private List<List<string>> allergens;
        private DBConnector dBConnector;

        public AllergenRepository()
        {
            Initialize();
        }

        private void Initialize()
        {
            dBConnector = new DBConnector();
        }

        /// <summary>
        /// Returns an object containing the allergens
        /// </summary>
        /// <returns>Contains multiple PlainAllergen objects, dependîng on how much datas there's in the DB</returns>
        public AllergenContainer GetAllergens()
        {
                allergens = GetPlainAllergensInDB();
                List<PlainAllergen> plainAllergens = new();
                foreach (var item in allergens)
                {
                    plainAllergens.Add(new PlainAllergen(int.Parse(item[0]), item[1]));
                }
                AllergenContainer allergensContainer = new AllergenContainer(plainAllergens);
                return allergensContainer;
        }

        private List<List<string>> GetPlainAllergensInDB()
        {
            string query = "SELECT * FROM allergen;";
            return dBConnector.Select(query);

        }
    }
}
