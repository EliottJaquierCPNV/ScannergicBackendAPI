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
            AllergenContainer expectedAllergens = new(new List<PlainAllergen>(){
                new PlainAllergen(2, "fruits à coque"),
                new PlainAllergen(1, "lactose")
            });
            AllergenContainer actualAllergens;

            //when
            actualAllergens = allergenRepository.GetAllergens();

            //then

            //TODO - Find another way to test that actualAllergens and expectedAllergens are the same

            //Assert.AreEqual(expectedAllergens, actualAllergens);
        }
    }
}