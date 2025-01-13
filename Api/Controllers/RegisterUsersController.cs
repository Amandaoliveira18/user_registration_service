using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("user-registration-service/users")]
    public class RegisterUsersController : ControllerBase
    {
        [HttpPost]
        [Route("nutritionists")]
        public IActionResult PostNutritionist(NutritionistUser nutritionistUser)
        {
            //nutritionistUser.Validate();

            return Ok("Nutricionista cadastrado com sucesso!");
        }
    }
}
