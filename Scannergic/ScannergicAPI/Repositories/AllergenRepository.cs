using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScannergicAPI.Entities;

namespace ScannergicAPI.Repositories
{
    public class AllergenRepository
    {
        //private List<Allergen> allergens = new()
        //{
        //    new Allergen(1, "lactose", new List<Ingredient>()
        //        {
        //            new Ingredient(1, "lait"),
        //            new Ingredient(2, "crème")
        //        }),
        //    new Allergen(2, "gluten", new List<Ingredient>()
        //        {
        //            new Ingredient(3, "farine"),
        //            new Ingredient(4, "blé")
        //        }),
        //    new Allergen(3, "fruits à coque", new List<Ingredient>()
        //        {
        //            new Ingredient(5, "cacahuètes"),
        //            new Ingredient(6, "huile d'arachide")
        //        })
        //};
        private AllergenRequester allergenRequester = new();
        private List<List<string>> allergens;

        public AllergenContainer GetAllergens()
        {
            try
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
            catch(UnableToConnectToTheServer)
            {
                throw;
            }
            catch (AccessDeniedToDB)
            {
                throw;
            }


        }

        //private string GetAllergen(string name)
        //{
        //    Allergen allergen = allergens.Where(allergen => allergen.Name == name).SingleOrDefault();
        //    return allergen.Name;
        //}
    }
}
