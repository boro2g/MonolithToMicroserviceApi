using Microsoft.Extensions.Logging;
using System;

namespace MonolithToMicroserviceApi.Shared.Core.Configuration
{
    public class EnvironmentVariables : IEnvironmentVariables
    {
        private readonly ILogger<EnvironmentVariables> _logger;

        public EnvironmentVariables(ILogger<EnvironmentVariables> logger)
        {
            _logger = logger;
        }

        public string GetString(string key, string defaultValue = "")
        {
            string value = Environment.GetEnvironmentVariable(key);

            return String.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        public int GetInt(string key, int defaultValue = 0)
        {
            return GetValue(key, Int32.Parse, defaultValue);
        }

        public decimal GetDecimal(string key, decimal defaultValue = 0)
        {
            return GetValue(key, Decimal.Parse, defaultValue);
        }

        public double GetDouble(string key, double defaultValue = 0)
        {
            return GetValue(key, Double.Parse, defaultValue);
        }

        private T GetValue<T>(string key, Func<string, T> converterFunction, T defaultValue)
        {
            string value = GetString(key);

            if (String.IsNullOrWhiteSpace(value))
            {
                _logger.LogWarning($"Could not find {typeof(T)} value for key: {key}");

                return defaultValue;
            }

            try
            {
                return converterFunction(value);
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not cast {typeof(T)} value for key: {key}", e);

                return defaultValue;
            }
        }
    }
}
