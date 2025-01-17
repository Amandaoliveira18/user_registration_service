using System.Data;
using Dapper;
using Domain.Adapters;
using Domain.Entities;
using Domain.Entities.Repository;
using Domain.Entities.Services;
using Domain.Entities.Services.Response;

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
            // Lista para construir os campos a serem atualizados dinamicamente
            var updates = new List<string>();
            var parameters = new Dictionary<string, object> { { "Id", id } };

            if (!string.IsNullOrEmpty(user.Name))
            {
                updates.Add("Name_User = @Name");
                parameters.Add("Name", user.Name);
            }
            if (!string.IsNullOrEmpty(user.Email))
            {
                updates.Add("Email = @Email");
                parameters.Add("Email", user.Email);
            }
            if (!string.IsNullOrEmpty(user.Password))
            {
                updates.Add("Password_User = @Password");
                parameters.Add("Password", user.Password);
            }
            if (user is NutritionistUser nutritionist)
            {
                if (!string.IsNullOrEmpty(nutritionist.License_Number))
                {
                    updates.Add("Lincese_Number = @LicenseNumber");
                    parameters.Add("LicenseNumber", nutritionist.License_Number);
                }
                if (!string.IsNullOrEmpty(nutritionist.Cpf))
                {
                    updates.Add("Cpf_User = @Cpf");
                    parameters.Add("Cpf", nutritionist.Cpf);
                }
            }

            // Verifica se há algo para atualizar
            if (updates.Count == 0)
            {
                return "No fields to update.";
            }

                    var query = $@"
                UPDATE mysqlDB.USERS
                SET {string.Join(", ", updates)}
                WHERE Id = @Id
            ";

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

        public async Task<NutritionistUserResponse?> GetNutritionist(string id)
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
                return await connection.QuerySingleOrDefaultAsync<NutritionistUserResponse?>(query, new { Id = id });
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

        public async Task<List<UserDTO?>> GetNutritionists()
        {
            const string query = @"
                SELECT *
                FROM mysqlDB.USERS
                WHERE Profile_User = 'Nutritionist'
            ";

            try
            {
                using var connection = _mySqlConnectionHelper.OpenConnection();
                var users = await connection.QueryAsync<UserDTO?>(query);
                return users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar lista de nutricionistas: {ex.Message}");
                throw;
            }
        }
    }
}
