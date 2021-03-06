using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MonolithToMicroserviceApi.Search.WebApi.Configuration;
using MonolithToMicroserviceApi.Shared.WebApi.Configuration;
using MonolithToMicroserviceApi.Shared.WebApi.Extensions;
using System.Collections.Generic;

namespace MonolithToMicroserviceApi.Search.WebApi
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
