using Domain.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface IUserRepository
    {
        Task<string> Insert(User user);
        Task<string> Update(User user);
        Task<string> Delete(string id);
        Task<PatientUser> GetPatient(string id);
        Task<NutritionistUser> GetNutritionist(string id);
        Task<List<string>> GetNutritionists();

    }
}
