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
                var stringConnection = "Server=localhost;Port=3306;Uid=root;Pwd=mysqlPW;Database=mysqlDB;";
                var connection = new MySqlConnection(stringConnection);
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
