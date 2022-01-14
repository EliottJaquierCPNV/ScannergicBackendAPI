using System;
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
        public AllergenContainer GetAllergens(string productNumber)
        {
            List<List<string>> allergens = GetPlainAllergensInDB(productNumber);
            List<PlainAllergen> plainAllergen = new();

            ProductExists(productNumber);

            if(allergens.Count != 0)
            {
                foreach(var allergen in allergens)
                {
                    plainAllergen.Add(new PlainAllergen(int.Parse(allergen[0]), allergen[1]));
                }
                return new AllergenContainer(plainAllergen);
            }
            else
            {
                return new AllergenContainer(new List<PlainAllergen>());
            }
        }

        private List<List<string>> GetPlainAllergensInDB()
        {
            string query = "SELECT * FROM allergen;";
            return dBConnector.Select(query);

        }

        private List<List<string>> GetPlainAllergensInDB(string productNumber)
        {
            long parsedProductNumber = 0;
            if (!long.TryParse(productNumber, out parsedProductNumber))
            {
                throw new ProductNotFound();
            }
            // TODO - Secure to avoid SQL injections
            string query = @"SELECT allergen.id, allergen.name FROM	product
INNER JOIN product_has_ingredient ON product.id = product_has_ingredient.product_id
INNER JOIN ingredient ON ingredient.id = product_has_ingredient.ingredient_id
INNER JOIN ingredient_has_allergen ON ingredient.id = ingredient_has_allergen.ingredient_id
INNER JOIN allergen ON allergen.id = ingredient_has_allergen.allergen_id
WHERE product.UPC =" + parsedProductNumber + ";";

            return dBConnector.Select(query); ;
        }
        private void ProductExists(string productNumber)
        {
            string query = "SELECT product.UPC FROM product WHERE product.UPC =" + productNumber + ";";
            List<List<string>> product = dBConnector.Select(query);
            if (product.Count == 0)
            {
                throw new ProductNotFound();
            }
        }
    }
    public class AllergenRepositoryException : Exception { }
    public class ProductNotFound : AllergenRepositoryException { }

}
