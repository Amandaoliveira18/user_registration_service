using Domain.Adapters;
using Domain.Adapters.Config;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase.ConnectionHelper
{
    public class MySqlConnectionHelper : IMySqlConnectionHelper
    {
        private readonly ConfigMySql _connectionString;
        public MySqlConnectionHelper(IOptions<ConfigMySql> connectionString)
        {
            _connectionString = connectionString.Value;
        }
        public MySqlConnection OpenConnection()
        {
            try
            {
                var connection = new MySqlConnection(_connectionString.ConnectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao MySQL: {ex.Message}");
                throw;
            }
        }
    }
}
