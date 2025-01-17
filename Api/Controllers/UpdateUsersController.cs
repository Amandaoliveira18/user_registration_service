using Domain.Entities.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    public class UpdateUsersController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        public UpdateUsersController(IUserControlService userControlService)
        {
            _userControlService = userControlService;
        }

        [HttpPut]
        [Route("patients/{id}")]
        public async Task<IActionResult> PutPatientAsync(string id, PatientUser patientUser)
        {
            try
            {
                var response = await _userControlService.UpdateUserAsync(patientUser, id);

                if (response.Success)
                    return Ok(new { id = response.Message, message = "Registro atualizado com sucesso!" });

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

        [HttpPut]
        [Route("nutritionists/{id}")]
        public async Task<IActionResult> PutNutritionistAsync(string id, NutritionistUser nutritionistUser)
        {
            try
            {
                var response = await _userControlService.UpdateUserAsync(nutritionistUser, id);

                if (response.Success)
                    return Ok(new { id = response.Message, message = "Registro atualizado com sucesso!" });

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
