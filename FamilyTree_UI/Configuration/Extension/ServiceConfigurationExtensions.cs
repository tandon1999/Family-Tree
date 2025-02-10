using FamilyTree_UI.Shared;
using FamilyTreeUI.Manager.Implementation;
using FamilyTreeUI.Manager.Interface;

namespace FamilyTree_UI.Configuration.Extension
{
    public static class ServiceConfigurationExtensions
    {
        internal static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
           // services.AddApiHandlers(_configuration);
            services.AddTransient<IFamilyTreeMemberManager, FamilyTreeMemberManager>();

            return services;
        }

        internal static IServiceCollection AddManagers(this IServiceCollection services)
        {
            var managers = typeof(IManager);

            var types = managers
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (managers.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
            }

            return services;
        }
        /*internal static IServiceCollection AddApiHandlers(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddHttpClient("ApiGateway", client =>
            {
                client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("RUNNING_IN_DOCKER") == "TRUE" ? Environment.GetEnvironmentVariable("API_GATEWAY")! : _configuration.GetSection("ApiUrl:ApiGateway").Value!);
            });
            //.AddHttpMessageHandler<AuthenticationHeaderHandler>();

            return services;
        }*/
    }
}
