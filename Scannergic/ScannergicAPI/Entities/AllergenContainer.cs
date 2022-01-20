using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScannergicAPI.Entities
{
    /// <summary>
    /// This record is designed to store a list of plain allergen objects.
    /// </summary>
    public record AllergenContainer(List<PlainAllergen> allergens);
}
