using Microsoft.AspNetCore.Mvc.Filters;
using MonolithToMicroserviceApi.Shared.Core.Configuration;
using System.Collections.Generic;

namespace MonolithToMicroserviceApi.Shared.WebApi.Filters
{
    public class ApiHeaderIdentifierActionFilter : IActionFilter
    {
        private readonly IEnvironmentVariables _environmentVariables;

        private readonly IEnumerable<string> _headers = new[] { "api_colour", "api_region", "api_environment", /*...*/ };

        public ApiHeaderIdentifierActionFilter(IEnvironmentVariables environmentVariables)
        {
            _environmentVariables = environmentVariables;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (string headerKey in _headers)
            {
                context.HttpContext?.Response.Headers.Add(headerKey, _environmentVariables.GetString(headerKey, "n/a"));
            }
        }
    }
}
