using Domain.Entities.Services;
using Domain.Entities.Services.Response;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserControlService
    {

        Task<ResultService> CreateUserAsync<TUser>(TUser user) where TUser : User;
        Task<ResultService> UpdateUserAsync<TUser>(TUser user, string updateId) where TUser : User;
        Task<ResultService> DeleteUserAsync(string id);
        Task<ResultService> GetUserAsync<TUser>(string id) where TUser : User;
        Task<IEnumerable<NutritionistUserResponse?>?> GetUsersAsync();

    }
}
