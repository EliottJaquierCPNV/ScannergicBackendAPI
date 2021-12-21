using Microsoft.AspNetCore.Mvc;
using ScannergicAPI.Repositories;
using ScannergicAPI.Entities;
//using HttpRequestMessageExtensions = System.Net.Http.HttpRequestMessageExtensions;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace ScannergicAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/allergens")]
    [ApiController]
    public class AllergensController : ControllerBase
    {
        private AllergenRepository repository;

        public AllergensController()
        {
            repository = new AllergenRepository();
        }

        [HttpGet]
        public ActionResult<AllergenContainer> GetAllergens()
        {
            try
            {
                return repository.GetAllergens();
            }
            catch (UnableToConnectToTheServer)
            {
                //return Request(HttpStatusCode.NotFound, "internal error");
                return StatusCode(500);
            }
            catch (AccessDeniedToDB)
            {
                return StatusCode(500);
            }
        }
    }
}
