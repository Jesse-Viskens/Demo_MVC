using DemoMVC.BLL.Services.Auto;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMVC.BLL
{
    public static class BLLExtension
    {
        public static IServiceCollection RegisterBLL(this IServiceCollection services)
        {

            services.AddTransient<IAutoService, AutoService>();

            return services;
        }
    }
}
