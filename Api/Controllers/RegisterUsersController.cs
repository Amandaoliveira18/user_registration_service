using Domain.Entities.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("user-registration-service/users")]
    public class RegisterUsersController : ControllerBase
    {
        private readonly IUserControlService _userControlService;
        public RegisterUsersController(IUserControlService userControlService)
        {
           _userControlService = userControlService;
        }
        [HttpPost]
        [Route("nutritionists")]
        public IActionResult PostNutritionist(NutritionistUser nutritionistUser)
        {
            try
            {
                //nutritionistUser.Validate();

                _userControlService.GetUser();
                return Ok(new { id = "teste", message = "Nutricionista cadastrado com sucesso!" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new {code = 400, message = ex.Message });
            }
        }
        [HttpPost]
        [Route("patients")]
        public IActionResult PostPatients(PatientUser nutritionistUser)
        {
            try
            {
                
                nutritionistUser.Validate();
                //service
                return Ok(new { id = "teste", message = "Paciente cadastrado com sucesso!" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }

    }
}
