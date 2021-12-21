using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScannergicAPI.Entities
{
    public class Ingredient
    {
        public Ingredient(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public int Id { get; }
    }
}
