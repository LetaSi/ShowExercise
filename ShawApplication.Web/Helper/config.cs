
using System.Configuration;

namespace ShawApplication.Web.Helper
{
    public class Config
    {
        public static string BaseUrl()
        {
            string baseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            if (string.IsNullOrEmpty(baseUrl)) { baseUrl = "http://localhost:64015/api/Client/"; }
            return baseUrl;
        }
    }
}