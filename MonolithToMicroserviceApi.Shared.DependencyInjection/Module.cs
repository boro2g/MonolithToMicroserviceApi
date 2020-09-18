using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MonolithToMicroserviceApi.Shared.DependencyInjection
{
    public abstract class Module
    {
        public abstract void Register(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
