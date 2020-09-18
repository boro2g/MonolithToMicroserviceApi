using MonolithToMicroserviceApi.Shared.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonolithToMicroserviceApi.Shared.WebApi.Configuration
{
    public abstract class ApiConfiguration
    {
        public virtual IEnumerable<Module> Modules { get; } = Enumerable.Empty<Module>();

        public virtual IEnumerable<Type> ActionFilters { get; } = Enumerable.Empty<Type>();
    }
}
