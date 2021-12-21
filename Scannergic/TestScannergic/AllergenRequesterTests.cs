using NUnit.Framework;
using ScannergicAPI.Repositories;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ServiceProcess;

namespace TestScannergic
{
    public class AllergenRequesterTests
    {
        DBConnector testConnectDB;
        [SetUp]
        public void Setup()
        {

        }

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

        [Test]
        public void GetPlainAllergensInDB_UnableToConnectToDB_Success()
        {
            //given
            AllergenRequester allergenRequester = new();

            //when
            ServiceController service = new ServiceController("MySQL80");
            if ((service.Status.Equals(ServiceControllerStatus.Running))){
                service.Stop();
            }

            //then
            Assert.Throws<AlergenRequesterException>(delegate
            {
                allergenRequester.GetPlainAllergensInDB();
            });

            service.Start();
        }
    }
}