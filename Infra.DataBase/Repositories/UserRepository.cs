using System.Data;
using Dapper;
using Domain.Adapters;
using Domain.Entities;
using Domain.Entities.Services;

namespace Infra.DataBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMySqlConnectionHelper _mySqlConnectionHelper;

        public UserRepository(IMySqlConnectionHelper mySqlConnectionHelper)
        {
            _mySqlConnectionHelper = mySqlConnectionHelper;
        }

        public async Task<string?> Insert(User user, EnumProfile enumProfile)
        {
            var uuid = Guid.NewGuid().ToString();
            const string query = @"
            INSERT INTO mysqlDB.USERS (Id, Name_User, Email, Password_User, Lincese_Number, Cpf_User, Profile_User)
            VALUES (@Id, @Name, @Email, @Password, @LicenseNumber, @Cpf, @Profile);
            SELECT LAST_INSERT_ID();
        ";
            var parameters = new
            {
                Id = uuid,
                user.Name,
                user.Email,
                user.Password,
                LicenseNumber = user is NutritionistUser nutritionist ? nutritionist.License_Number : null,
                Cpf = user is NutritionistUser nutritionistUser ? nutritionistUser.Cpf : null,
                Profile = enumProfile.ToString()
            };

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                var id = await connection.ExecuteScalarAsync<string>(query, parameters);

                if (id != null)
                    return uuid;

                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir usuário: {ex.Message}");
                throw;
            }
        }

        public async Task<string?> Update(User user, string id)
        {
            const string query = @"
                UPDATE mysqlDB.USERS
                SET Name_User = @Name, Email = @Email, Password_User = @Password,
                    Lincese_Number = @LicenseNumber, Cpf_User = @Cpf
                WHERE Id = @Id
            ";

            var parameters = new
            {
                Id = id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                LicenseNumber = user is NutritionistUser nutritionist ? nutritionist.License_Number : null,
                Cpf = user is NutritionistUser nutritionistUser ? nutritionistUser.Cpf : null
            };

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0 ? "User updated successfully" : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar usuário: {ex.Message}");
                throw;
            }
        }

        public async Task<string?> Delete(string id)
        {
            const string query = "DELETE FROM mysqlDB.USERS WHERE Id = @Id";

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0 ? "User deleted successfully" : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir usuário: {ex.Message}");
                throw;
            }
        }

        public async Task<NutritionistUser?> GetNutritionist(string id)
        {
            const string query = @"
                SELECT Id, Name_User AS Name, Email, Password_User AS Password,
                       Lincese_Number AS License_Number, Cpf_User AS Cpf
                FROM mysqlDB.USERS
                WHERE Id = @Id AND Profile_User = 'Nutritionist'
            ";

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                return await connection.QuerySingleOrDefaultAsync<NutritionistUser>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar nutricionista: {ex.Message}");
                throw;
            }
        }

        public async Task<PatientUser?> GetPatient(string id)
        {
            const string query = @"
                SELECT Id, Name_User AS Name, Email, Password_User AS Password
                FROM mysqlDB.USERS
                WHERE Id = @Id AND Profile_User = 'Patient'
            ";

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                return await connection.QuerySingleOrDefaultAsync<PatientUser>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar paciente: {ex.Message}");
                throw;
            }
        }

        public async Task<List<string?>> GetNutritionists()
        {
            const string query = @"
                SELECT Id
                FROM mysqlDB.USERS
                WHERE Profile_User = 'Nutritionist'
            ";

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                var ids = await connection.QueryAsync<string?>(query);
                return ids.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar lista de nutricionistas: {ex.Message}");
                throw;
            }
        }
    }
}
