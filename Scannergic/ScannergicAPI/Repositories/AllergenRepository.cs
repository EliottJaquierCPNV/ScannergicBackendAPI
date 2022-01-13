using System.Collections.Generic;
using ScannergicAPI.Entities;

namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Is responsible of providing requested Allergen datas
    /// </summary>
    public class AllergenRepository
    {
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
            List<List<string>> allergens = GetPlainAllergensInDB();
            List<PlainAllergen> plainAllergens = new();

                foreach (var item in allergens)
                {
                    plainAllergens.Add(new PlainAllergen(int.Parse(item[0]), item[1]));
                }
                AllergenContainer allergensContainer = new AllergenContainer(plainAllergens);
                return allergensContainer;
        }
        public AllergenContainer GetAllergen(string productNumber)
        {
            List<string> allergen = GetPlainAllergenInDB(productNumber);
            List<PlainAllergen> plainAllergen = new();

            // TODO - Manage the case where product has several allergens

            plainAllergen.Add(new PlainAllergen(int.Parse(allergen[0]), allergen[1]));

            return new AllergenContainer(plainAllergen);
        }

        private List<List<string>> GetPlainAllergensInDB()
        {
            string query = "SELECT * FROM allergen;";
            return dBConnector.Select(query);

        }

        // TODO - Implement the case where product is not found (return error to the client)
        private List<string> GetPlainAllergenInDB(string productNumber)
        {
            string query = @"SELECT allergen.id, allergen.name FROM	product
INNER JOIN product_has_ingredient ON product.id = product_has_ingredient.product_id
INNER JOIN ingredient ON ingredient.id = product_has_ingredient.ingredient_id
INNER JOIN ingredient_has_allergen ON ingredient.id = ingredient_has_allergen.ingredient_id
INNER JOIN allergen ON allergen.id = ingredient_has_allergen.ingredient_id
WHERE product.UPC =" + productNumber + ";";
            List<List<string>> result = dBConnector.Select(query);

            return result[0];
        }
    }
}
