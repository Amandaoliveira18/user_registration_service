using Domain.Adapters;
using Domain.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMySqlConnectionHelper _mySqlConnectionHelper;
        public UserRepository(IMySqlConnectionHelper mySqlConnectionHelper) 
        {
            _mySqlConnectionHelper = mySqlConnectionHelper;
        }

        public Task<string> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<NutritionistUser> GetNutritionist(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetNutritionists()
        {
            throw new NotImplementedException();
        }

        public Task<PatientUser> GetPatient(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
