using Application.Services;
using Domain.Adapters.Config;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModuleDependency
    {
        public static void AddApplicationModule(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<ConfigMySql>(configuration.GetSection("ConfigMySql"));
            services.AddTransient<IUserControlService, UserControlService>();


        }
    }
}
