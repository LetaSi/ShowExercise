using Newtonsoft.Json;
using ShawApplication.Web.Objects;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShawApplication.Web.Helper
{
    public class ShowServiceHelper
    {

        public async Task<List<Show>> GetShowsAsync()
        {

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(Config.BaseUrl()).Result;
                string result = await response.Content.ReadAsStringAsync();
                result = CleanJsonString(result);

                return (List<Show>)JsonConvert.DeserializeObject(result, typeof(List<Show>));
            }
        }

        public async Task<Show> GetShowById(int id)
        {
            string uri = Config.BaseUrl() + id.ToString();
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = httpClient.GetAsync(uri).Result;
                string result = await response.Content.ReadAsStringAsync();
                result = CleanJsonString(result);
                return (Show)JsonConvert.DeserializeObject(result, typeof(Show));

                //Task<String> response = httpClient.GetStringAsync(uri);
                //return JsonConvert.DeserializeObjectAsync<Show>(response.Result).Result;
            }
        }

        private string CleanJsonString(string json)
        {
            json = json.TrimStart('\"');
            json = json.TrimEnd('\"');
            json = json.Replace("\\", "");

            return json;
        }
    }
}
