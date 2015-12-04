using Newtonsoft.Json;
using ShawApplication.API.Models;
using System.Web.Http;

namespace ShawApplication.API.Controllers
{
    public class ClientController : ApiController
    {
        IShowRepository showRepository = new ShowRepository();

        public ClientController()
        {

        }

        public string Get()
        {
            return JsonConvert.SerializeObject(showRepository.GetAll());
        }

        public string Get(int id)
        {
            return JsonConvert.SerializeObject(showRepository.Find(id));
        }

    }
}