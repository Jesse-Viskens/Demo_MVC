using DemoMVC.DAL.Data;
using DemoMVC.DAL.Data.Repositories.Auto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMVC.DAL
{
    public static class DALExtension
    {
        public static IServiceCollection RegisterDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VoertuigDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AutoContext")));




            services.AddTransient<IAutoRepository, AutoRepository>();

            return services;
        }
    }
}
