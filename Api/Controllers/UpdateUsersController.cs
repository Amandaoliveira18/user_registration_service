using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    public class UpdateUsersController : ControllerBase
    {
        [HttpPut]
        [Route("patients/{id}")]
        public IActionResult PutPatient(PatientUser patientUser)
        {
            try
            {
                //service
                return Ok(new { id = "teste", message = "Registro atualizado com sucesso!" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("nutritionists/{id}")]
        public IActionResult PutNutritionist(NutritionistUser nutritionistUser)
        {
            try
            {
                //service
                return Ok(new { id = "teste", message = "Registro atualizado com sucesso!" });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { code = 400, message = ex.Message });
            }
        }
    }
}
