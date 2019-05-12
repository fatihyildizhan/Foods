using System.Configuration;

namespace Foods.Data
{
    public static class Helper
    {
        public static string ConValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
