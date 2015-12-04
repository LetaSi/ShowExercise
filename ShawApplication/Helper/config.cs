
using System.Configuration;

namespace ShawApplication.API.Helper
{
    public class Config
    {
        public static string BaseUrl()
        {
            string baseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            if (string.IsNullOrEmpty(baseUrl)) { baseUrl = "http://localhost:64015/ShowImages/"; }
            return baseUrl;
        }
    }
}