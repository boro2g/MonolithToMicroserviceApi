using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonolithToMicroserviceApi.Shared.DependencyInjection;
using MonolithToMicroserviceApi.Shared.Services.Web;

namespace MonolithToMicroserviceApi.Shared.Services.DependencyInjection
{
    public class SharedServicesModule : Module
    {
        public override void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<ExampleSharedService>();
        }
    }
}
