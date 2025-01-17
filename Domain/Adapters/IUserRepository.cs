using Domain.Entities;
using Domain.Entities.Repository;
using Domain.Entities.Services;
using Domain.Entities.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface IUserRepository
    {
        Task<string?> Insert(User user, EnumProfile enumProfile);
        Task<string?> Update(User user, string id);
        Task<string?> Delete(string id);
        Task<PatientUser?> GetPatient(string id);
        Task<NutritionistUserResponse?> GetNutritionist(string id);
        Task<List<UserDTO?>> GetNutritionists();

    }
}
