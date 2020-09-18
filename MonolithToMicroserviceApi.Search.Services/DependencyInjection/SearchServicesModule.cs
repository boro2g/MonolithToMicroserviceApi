using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonolithToMicroserviceApi.Shared.DependencyInjection;

namespace MonolithToMicroserviceApi.Search.Services.DependencyInjection
{
    public class SearchServicesModule : Module
    {
        public override void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddTransient<ISearchService, SearchService>();
        }
    }
}
