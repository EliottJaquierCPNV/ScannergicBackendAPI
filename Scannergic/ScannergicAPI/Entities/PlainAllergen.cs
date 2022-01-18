using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScannergicAPI.Entities
{
    /// <summary>
    /// This record is used to store only the basic and needed information of an allergen
    /// </summary>
    public record PlainAllergen(int id, string name);
}
