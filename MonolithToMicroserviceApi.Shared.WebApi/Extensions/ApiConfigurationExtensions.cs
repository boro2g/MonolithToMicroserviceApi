using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonolithToMicroserviceApi.Shared.DependencyInjection;
using MonolithToMicroserviceApi.Shared.DependencyInjection.Extensions;
using MonolithToMicroserviceApi.Shared.Services.DependencyInjection;
using MonolithToMicroserviceApi.Shared.WebApi.Configuration;
using System;
using System.Collections.Generic;

namespace MonolithToMicroserviceApi.Shared.WebApi.Extensions
{
    public static class ApiConfigurationExtensions
    {
        public static void RegisterApiConfigurations(this IEnumerable<ApiConfiguration> apiConfigurations,
            IServiceCollection services,
            IMvcBuilder mvcBuilder,
            IConfiguration configuration)
        {
            foreach (ApiConfiguration apiConfiguration in apiConfigurations)
            {
                RegisterApiConfiguration(services, mvcBuilder, apiConfiguration, configuration);
            }
        }

        private static void RegisterApiConfiguration(IServiceCollection services, IMvcBuilder mvcBuilder, ApiConfiguration apiConfiguration, IConfiguration configuration)
        {
            AddActionFilters(apiConfiguration, mvcBuilder);
            AddApplicationParts(apiConfiguration, mvcBuilder);
            AddModules(apiConfiguration, services, configuration);
        }

        private static void AddActionFilters(ApiConfiguration apiConfiguration, IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddMvcOptions(config =>
            {
                foreach (Type actionFilter in apiConfiguration.ActionFilters)
                {
                    config.Filters.AddService(actionFilter);
                }
            });
        }

        private static void AddApplicationParts(ApiConfiguration apiConfiguration, IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddApplicationPart(apiConfiguration.GetType().Assembly);
        }

        private static void AddModules(ApiConfiguration apiConfiguration, IServiceCollection services, IConfiguration configuration)
        {
            foreach (Module apiModule in apiConfiguration.Modules)
            {
                services.RegisterModule(configuration, apiModule);
            }

            _ = services.RegisterModule<SharedServicesModule>(configuration);
        }
    }
}
