namespace MonolithToMicroserviceApi.Shared.Core.Configuration
{
    public interface IEnvironmentVariables
    {
        decimal GetDecimal(string key, decimal defaultValue = 0);
        double GetDouble(string key, double defaultValue = 0);
        int GetInt(string key, int defaultValue = 0);
        string GetString(string key, string defaultValue = "");
    }
}
