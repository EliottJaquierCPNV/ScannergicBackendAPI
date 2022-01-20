using System;
using Microsoft.AspNetCore.Mvc;
using ScannergicAPI.Repositories;
using ScannergicAPI.Entities;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using MySql.Data.MySqlClient;

namespace ScannergicAPI.Controllers
{
    /// <summary>
    /// This class is an api controller which inherits from the ControllerBase class.
    /// It manages to return the requested datas or http error code depending on the reached route.
    /// </summary>
    [Route("api/allergens")]
    [ApiController]
    public class AllergensController : ControllerBase
    {
        private AllergenRepository repository;

        /// <summary>
        /// This controller initialize a new AllergenRepository object when a new AllergenController is created
        /// </summary>
        public AllergensController()
        {
            repository = new AllergenRepository();
        }
        /// <summary>
        /// Returns a list of all the allergens
        /// </summary>
        /// <returns>List of allergens or http error code</returns>
        [HttpGet]
        public ActionResult<AllergenContainer> GetAllergens()
        {
            try
            {
                return repository.GetAllergens();
            }
            catch (MySqlException)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// this functions returns allergens contained in a specific product identified by the productNumber parameter.
        /// </summary>
        /// <param name="productNumber"> The product number sent by the client </param>
        /// <returns> An object containing a list of allergen or http error code 500/404 </returns>
        [HttpGet("{productNumber}")]
        public ActionResult<AllergenContainer> GetAllergens(string productNumber)
        {
            try
            {
                return repository.GetAllergens(productNumber);
            }
            catch (MySqlException)
            {
                return StatusCode(500);
            }
            catch (ProductNotFound)
            {
                return NotFound();
            }
        }
    }
}
