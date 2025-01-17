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
        public async Task<IActionResult> PostNutritionistAsync(NutritionistUser nutritionistUser)
        {
            try
            {
                var response = await _userControlService.CreateUserAsync(nutritionistUser);

                if (response.Success)
                    return Ok(new { id = response.Message, message = "Nutricionista cadastrado com sucesso!" });

                return NotFound(new { code = 400, message = response.Message });

            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { code = 500, message = ex.Message });
            }
        }
        [HttpPost]
        [Route("patients")]
        public async Task<IActionResult> PostPatientsAsync(PatientUser patientUser)
        {
            try
            {
                var response = await _userControlService.CreateUserAsync(patientUser);

                if (response.Success)
                    return Ok(new { id = response.Message, message = "Paciente cadastrado com sucesso!" });

                return NotFound(new { code = 400, message = response.Message });

            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { code = 500, message = ex.Message });
            }
        }

    }
}
