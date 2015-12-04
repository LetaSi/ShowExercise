using ShawApplication.API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ShawApplication.API.Controllers
{

    public class ServicesController : ApiController
    {
        IShowRepository showRepository = new ShowRepository();

        public IEnumerable<Show> Get()
        {
            return showRepository.GetAll();
        }

        public Show Get(int id)
        {
            return showRepository.Find(id);
        }
        
        public void Post(Show show)
        {
            try
            {
                showRepository.Add(show);
            }
            catch (Exception) { }
        }

        public void Put(List<string> val)
        {
            int id = Convert.ToInt32(val[0]);
            Show obj = showRepository.Find(id);
            obj.Name = val[1];
            obj.Description = val[2];
            showRepository.Update(obj);
        }

        public void Delete(List<string> val)
        {
            int id = Convert.ToInt32(val[0]);
            showRepository.Remove(id);
        }

    }
}
