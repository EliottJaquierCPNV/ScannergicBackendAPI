using System;
using Microsoft.AspNetCore.Mvc;
using ScannergicAPI.Repositories;
using ScannergicAPI.Entities;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using MySql.Data.MySqlClient;

namespace ScannergicAPI.Controllers
{
    [Route("api/allergens")]
    [ApiController]
    public class AllergensController : ControllerBase
    {
        private AllergenRepository repository;

        public AllergensController()
        {
            repository = new AllergenRepository();
        }
        /// <summary>
        /// Returns a list of all the allergens as a JSON
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
        [HttpGet("{productNumber}")]
        public ActionResult<AllergenContainer> GetAllergensByProduct(string productNumber)
        {
            try
            {
                return repository.GetAllergen(productNumber);
            }
            catch (MySqlException)
            {
                return StatusCode(500);
            }
        }
    }
}
