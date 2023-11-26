using BlazorWASM.Server.DB;
using BlazorWASM.Server.DB.Alerts;
using BlazorWASM.Server.DB.Devices;
using BlazorWASM.Server.DB.Locations;
using BlazorWASM.Server.DB.Users;

namespace BlazorWASM.Server.Initialization
{
    public static class RegisterDependencies
    {
        public static IServiceCollection AddDependencies(
                       this IServiceCollection services)
        {
            services.AddSingleton<CosmosConfigurationProvider>();
            return services;
        }
    }
}
