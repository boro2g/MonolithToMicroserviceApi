using MonolithToMicroserviceApi.Search.Services.DependencyInjection;
using MonolithToMicroserviceApi.Shared.DependencyInjection;
using MonolithToMicroserviceApi.Shared.WebApi.Configuration;
using System.Collections.Generic;

namespace MonolithToMicroserviceApi.Search.WebApi.Configuration
{
    public class SearchApiConfiguration : ApiConfiguration
    {
        public override IEnumerable<Module> Modules => new[] { new SearchServicesModule() };
    }
}
