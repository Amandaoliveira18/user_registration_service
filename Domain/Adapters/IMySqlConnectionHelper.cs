using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Adapters
{
    public interface IMySqlConnectionHelper
    {
        MySqlConnection OpenConnection();
    }
}
