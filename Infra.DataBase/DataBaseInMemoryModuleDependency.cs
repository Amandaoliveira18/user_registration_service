using Domain.Adapters;
using Infra.DataBase.ConnectionHelper;
using Infra.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.DataBase
{
    public static class DataBaseInMemoryModuleDependency
    {
        public static void AddDataBaseInMemoryModule(this IServiceCollection services)
        {
            services.AddTransient<IMySqlConnectionHelper, MySqlConnectionHelper>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
