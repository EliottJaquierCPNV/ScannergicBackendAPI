using NUnit.Framework;
using ScannergicAPI.Repositories;
using System.Collections.Generic;

namespace TestScannergic
{
    public class AllergenRequesterTests
    {
        [Test]
        public void GetPlainAllergensInDB_InitialCase_Success()
        {
            //given
            AllergenRequester allergenRequester = new();
            List<List<string>> expectedAllergens = new(){
                new List<string>()
                {
                    "2", "fruits à coque"
                },
                new List<string>(){
                    "1","lactose"
                }
            };
            List<List<string>> actualAllergens = new();

            //when
            actualAllergens = allergenRequester.GetPlainAllergensInDB();

            //then
            CollectionAssert.AreEqual(expectedAllergens, actualAllergens);
        }
    }
}