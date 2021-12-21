using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScannergicAPI.Entities
{
    public class Allergen
    {
        private string name;
        private int id;
        private List<Ingredient> allergenIngredients = new();
        public Allergen(int id, string name, List<Ingredient> allergenIngredients)
        {
            this.id = id;
            this.name = name;
            this.allergenIngredients = allergenIngredients;
        }
        public string Name { get => name; }
        public int Id { get => id; }
        public List<Ingredient> AllergenIngredients { get => allergenIngredients; }
    }
}
