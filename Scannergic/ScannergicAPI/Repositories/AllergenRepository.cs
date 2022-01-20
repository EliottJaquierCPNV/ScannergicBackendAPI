using System;
using System.Collections.Generic;
using ScannergicAPI.Entities;

namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Is responsible of providing Allergen datas
    /// </summary>
    public class AllergenRepository
    {
        private DBConnector dBConnector;

        /// <summary>
        /// This connector initializes a new DBconnector objects in order to access the database
        /// </summary>
        public AllergenRepository()
        {
            dBConnector = new DBConnector();
        }
        /// <summary>
        /// Returns all the allergens contained in the database
        /// </summary>
        /// <returns>An AllergenContainer object containing allergens</returns>
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
        /// <summary>
        /// Returns the allergens contained in a specific product
        /// </summary>
        /// <param name="productNumber"> Product number given by the client (should be a 13 digits number) </param>
        /// <returns> A list of the allergens contained in the DB. The list can be empty if the object does not contain any allergens</returns>
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
        /// <summary>
        /// Selects all the allergens contained in the DB
        /// </summary>
        /// <returns> A list of lists of string containing the allergens</returns>
        private List<List<string>> GetPlainAllergensInDB()
        {
            string query = "SELECT * FROM allergen;";
            return dBConnector.Select(query);

        }
        /// <summary>
        /// Selects all the allergens contained in the specified product in the DB
        /// </summary>
        /// <param name="productNumber"></param>
        /// <returns> A list of lists of string containing the allergens</returns>
        /// <exception cref="ProductNotFound">Thrown when a product is not found in the DB</exception>
        private List<List<string>> GetPlainAllergensInDB(string productNumber)
        {
            //protection against sql injections
            long parsedProductNumber = 0;
            if (!long.TryParse(productNumber, out parsedProductNumber))
            {
                throw new ProductNotFound();
            }
            string query = @"SELECT DISTINCT allergen.id, allergen.name FROM	product
INNER JOIN product_has_ingredient ON product.id = product_has_ingredient.product_id
INNER JOIN ingredient ON ingredient.id = product_has_ingredient.ingredient_id
INNER JOIN ingredient_has_allergen ON ingredient.id = ingredient_has_allergen.ingredient_id
INNER JOIN allergen ON allergen.id = ingredient_has_allergen.allergen_id
WHERE product.UPC =" + parsedProductNumber + ";";

            return dBConnector.Select(query); ;
        }
        /// <summary>
        /// Checks if the product exists in the DB to make the difference when a product
        /// has no allergens and a product doesn't exist
        /// </summary>
        /// <param name="productNumber"></param>
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
    /// <summary>
    /// Exceptions of the AllergenRepository class
    /// </summary>
    public class AllergenRepositoryException : Exception { }
    /// <summary>
    /// Thrown when a product is not found in the DB
    /// </summary>
    public class ProductNotFound : AllergenRepositoryException { }

}
