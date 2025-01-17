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
        public async Task<string> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(string user)
        {
            throw new NotImplementedException();
        }

        public Task<NutritionistUser> GetNutritionist(NutritionistUser nutritionistUser)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetNutritionists(NutritionistUser nutritionistUser)
        {
            throw new NotImplementedException();
        }

        public Task<PatientUser> GetPatient(PatientUser patientUser)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetPatients(PatientUser patientUser)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Insert(User user)
        {
            _mySqlConnectionHelper.OpenConnection();

            var teste = "ola";
            return teste;
        }

        public async Task<string> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
