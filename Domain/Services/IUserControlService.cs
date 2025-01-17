using Domain.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserControlService
    {
        Task<ResultService> CreateNutritionistUserAsync(NutritionistUser nutritionistUser);
        Task<ResultService> CreatePatientUserAsync(PatientUser nutritionistUser);
        Task<ResultService> UpdateNutritionistUserAsync(NutritionistUser nutritionistUser);
        Task<ResultService> UpdatePatientUserAsync(PatientUser nutritionistUser);

        Task<ResultService> DeleteUserAsync(string id);
        Task<ResultService> GetPatientAsync(string id);
        Task<ResultService> GetNutritionistAsync(string id);
        Task<ResultService> GetNutritionistsAsync();
    }
}
