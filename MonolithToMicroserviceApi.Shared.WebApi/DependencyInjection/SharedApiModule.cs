using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonolithToMicroserviceApi.Shared.Core.Configuration;
using MonolithToMicroserviceApi.Shared.DependencyInjection;
using MonolithToMicroserviceApi.Shared.WebApi.Filters;

namespace MonolithToMicroserviceApi.Shared.WebApi.DependencyInjection
{
    public class SharedApiModule : Module
    {
        public override void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            RegisterActionFilters(serviceCollection);

            serviceCollection.AddSingleton<IEnvironmentVariables, EnvironmentVariables>();
        }

        private void RegisterActionFilters(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ApiHeaderIdentifierActionFilter>();
        }
    }
}
