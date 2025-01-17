using Domain.Entities.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    public class ListUsersController : ControllerBase
    {

        [HttpGet]
        [Route("nutritionists")]
        public IActionResult GetListNutritionists()
        {
            try
            {
                var nutri1 = new NutritionistUser()
                {
                    Cpf = "teste"
                };

                var nutri2 = new NutritionistUser()
                {
                    Cpf = "tets"
                };

                var list = new List<NutritionistUser>
                {
                    nutri1,
                    nutri2
                };
                //service
                return Ok(list);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }
        [HttpGet]
        [Route("patients")]
        public IActionResult GetListPatients()
        {
            try
            {
                //service
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }
    }
}
