﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScannergicAPI.Entities
{
    public record AllergenContainer(IEnumerable<PlainAllergen> allergens);
}