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
                new PlainAllergen(3, "arachide"),
                new PlainAllergen(1, "gluten"),
                new PlainAllergen(2, "lactose")
            };
            List<PlainAllergen> actualAllergens;

            //when
            actualAllergens = allergenRepository.GetAllergens().allergens;

            //then
            CollectionAssert.AreEqual(expectedAllergens, actualAllergens);
        }
    }
}