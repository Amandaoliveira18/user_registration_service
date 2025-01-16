using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("user-registration-service")]
    public class DeleteUsersController : ControllerBase
    {

        [HttpDelete]
        [Route("nutritionists/{id}")]
        public IActionResult DeleteNutritionist()
        {
            try
            {
                //service
                return Ok(new { id = "teste", message = "Nutricionista cadastrado com sucesso!" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("patients/{id}")]
        public IActionResult DeletePatient()
        {
            try
            {
                //service
                return Ok(new { id = "teste", message = "O Paciente foi excluído com sucesso!" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }
    }
}
