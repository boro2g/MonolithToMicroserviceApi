using MonolithToMicroserviceApi.Shared.DependencyInjection;
using MonolithToMicroserviceApi.Shared.WebApi.DependencyInjection;
using MonolithToMicroserviceApi.Shared.WebApi.Filters;
using System;
using System.Collections.Generic;

namespace MonolithToMicroserviceApi.Shared.WebApi.Configuration
{
    public class SharedApiConfiguration : ApiConfiguration
    {
        public override IEnumerable<Module> Modules => new[]
        {
            new SharedApiModule(),
        };

        public override IEnumerable<Type> ActionFilters { get; } = new[]
        {
            typeof(ApiHeaderIdentifierActionFilter),
        };
    }
}
