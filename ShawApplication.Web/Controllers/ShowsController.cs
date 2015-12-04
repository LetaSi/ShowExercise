using ShawApplication.Web.Helper;
using ShawApplication.Web.Models;
using ShawApplication.Web.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShawApplication.Web.Controllers
{
    public class ShowsController : Controller
    {
        //
        // GET: /Shows/
        private ShowServiceHelper service = new ShowServiceHelper();

        public async Task<ActionResult> Index()
        {
            List<Show> shows = await service.GetShowsAsync();

            ShowListViewModel model = new ShowListViewModel();

            ShowListViewModel.PopulateViewModel(shows, model);

            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            Show show = await service.GetShowById(id);
            return View(show);
        }

    }
}
