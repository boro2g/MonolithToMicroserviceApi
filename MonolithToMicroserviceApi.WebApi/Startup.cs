using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonolithToMicroserviceApi.Search.WebApi.Configuration;
using MonolithToMicroserviceApi.Shared.WebApi.Configuration;
using MonolithToMicroserviceApi.Shared.WebApi.Extensions;
using System.Collections.Generic;

namespace MonolithToMicroserviceApi.WebApi
{
    public class Startup
    {
        private readonly IEnumerable<ApiConfiguration> _apiConfigurations;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _apiConfigurations = new ApiConfiguration[]
            {
                new SharedApiConfiguration(),
                new SearchApiConfiguration()
            };
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllers();

            /*
             * Before adding new service registrations, check the associated Modules within the _apiConfigurations
             * as these already contain a lot of service/component registrations
             */

            _apiConfigurations.RegisterApiConfigurations(services, mvcBuilder, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
