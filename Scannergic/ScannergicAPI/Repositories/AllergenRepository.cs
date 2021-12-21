using System.Collections.Generic;
using ScannergicAPI.Entities;

namespace ScannergicAPI.Repositories
{
    /// <summary>
    /// Is responsible of providing requested Allergen datas
    /// </summary>
    public class AllergenRepository
    {
        private AllergenRequester allergenRequester = new();
        private List<List<string>> allergens;

        /// <summary>
        /// Returns an object containing the allergens
        /// </summary>
        /// <returns>Contains multiple PlainAllergen objects, dependîng on how much datas there's in the DB</returns>
        public AllergenContainer GetAllergens()
        {
                allergens = allergenRequester.GetPlainAllergensInDB();
                List<PlainAllergen> plainAllergens = new();
                foreach (var item in allergens)
                {
                    plainAllergens.Add(new PlainAllergen(int.Parse(item[0]), item[1]));
                }
                AllergenContainer allergensContainer = new AllergenContainer(plainAllergens);
                return allergensContainer;
        }

        //private string GetAllergen(string name)
        //{
        //    Allergen allergen = allergens.Where(allergen => allergen.Name == name).SingleOrDefault();
        //    return allergen.Name;
        //}
    }
}
