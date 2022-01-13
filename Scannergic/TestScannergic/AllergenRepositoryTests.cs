using NUnit.Framework;
using ScannergicAPI.Repositories;
using System.Collections.Generic;
using ScannergicAPI.Entities;

namespace TestScannergic
{
    public class AllergenRepositoryTests
    {
        [Test]
        public void GetPlainAllergensInDB_InitialCase_Success()
        {
            //given
            AllergenRepository allergenRepository = new();
            List<PlainAllergen> expectedAllergens = new List<PlainAllergen>(){
                new PlainAllergen(2, "fruits à coque"),
                new PlainAllergen(1, "lactose")
            };
            List<PlainAllergen> actualAllergens;

            //when
            actualAllergens = allergenRepository.GetAllergens().allergens;

            //then
            CollectionAssert.AreEqual(expectedAllergens, actualAllergens);
        }
    }
}