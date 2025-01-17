using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("user-registration-service")]
    public class DeleteUsersController : ControllerBase
    {
        private readonly IUserControlService _userControlService;
        public DeleteUsersController(IUserControlService userControlService) 
        {
           _userControlService = userControlService;
        }

        [HttpDelete]
        [Route("nutritionists/{id}")]
        public async Task<IActionResult> DeleteNutritionistAsync(string id)
        {
            try
            {
                var response = await _userControlService.DeleteUserAsync(id);

                if (response.Success)
                    return Ok(new { id = response.Message, message = "Nutricionista excluido com sucesso!" });

                return BadRequest(response.Data);

            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { code = 500, message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("patients/{id}")]
        public async Task<IActionResult> DeletePatientAsync(string id)
        {
            try
            {
                var response = await _userControlService.DeleteUserAsync(id);

                if (response.Success)
                    return Ok(new { id = response.Message, message = "Paciente excluido com sucesso!" });

                return BadRequest(response.Data);

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
