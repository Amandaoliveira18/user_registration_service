using Domain.Entities.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    public class GetUsersController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        public GetUsersController(IUserControlService userControlService)
        {
            _userControlService = userControlService;
        }

        [HttpGet]
        [Route("nutritionists")]
        public async Task<IActionResult> GetListNutritionistsAsync()
        {
            try
            {
                var response = await _userControlService.GetUsersAsync();

                if (response.Success)
                    return Ok(new { response.Data });

                return NotFound(new {code= 404, message = "Lista não localizada"});

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
        [HttpGet]
        [Route("nutritionists/{id}")]
        public async Task<IActionResult> GetNutritionistAsync(string id)
        {
            try
            {
                var response = await _userControlService.GetUserAsync<NutritionistUser>(id);

                if (response.Success)
                    return Ok(new { response.Data });

                return NotFound(new { code = 404, message = "Id Não encontrado" });

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
        [HttpGet]
        [Route("patients/{id}")]
        public async Task<IActionResult> GetPatientAsync(string id)
        {
            try
            {
                var response = await _userControlService.GetUserAsync<PatientUser>(id);

                if (response.Success)
                    return Ok(new { response.Data });

                return NotFound(new { code = 404, message = "Id Não encontrado" });

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
