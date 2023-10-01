

using System.Configuration;

namespace HelperLib
{
    public static class Tools
    {
        public static string GetConnectionString(string name = "DF")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
