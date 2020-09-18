using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MonolithToMicroserviceApi.Shared.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterModule(this IServiceCollection collection, IConfiguration configuration, Module module)
        {
            module.Register(collection, configuration);

            return collection;
        }

        public static IServiceCollection RegisterModule<T>(this IServiceCollection collection, IConfiguration configuration)
            where T : Module, new()
        {
            var module = new T();

            module.Register(collection, configuration);

            return collection;
        }
    }
}
