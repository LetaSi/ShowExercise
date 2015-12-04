using ShawApplication.API.Helper;
using ShawApplication.API.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShawApplication.API.Controllers
{
    public class ShowController : Controller
    {
        #region varibles

        List<UploadFileInfo> ls = null;
        ServicesController db = new ServicesController();

        #endregion        

        #region Action Result
        public ActionResult Index()
        {
            IEnumerable<Show> list = db.Get();
            return View(list);
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Show show = db.Get(id);
            return View(show);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Show show, FormCollection collection)
        {
            try
            {
                List<UploadFileInfo> source = UploadHelper.files;
                List<UploadFileInfo> target = new List<UploadFileInfo>();
                string[] fs = collection.GetValues("files");

                if (fs != null && source != null)
                {
                    var curfiles = from f in source
                                   join t in fs.AsEnumerable() on f.FileName equals t
                                   orderby f.FileName
                                   select f;
                    target = curfiles.ToList();
                }

                if (target.Count == 1) // only all single images upload , set on client 
                {
                    show.ImageUrl = Config.BaseUrl() + target[0].FileName;
                    SaveImageToDisk((UploadFileInfo)target[0]);
                }

                db.Post(show);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Show show = db.Get(id);
            return View(show);
        }

        public ActionResult Delete(int id)
        {
            Show show = db.Get(id);
            return View(show);
        }
        #endregion

        #region upload images
        private void SaveImageToDisk(UploadFileInfo PostedFile)
        {
            string imagePath = Server.MapPath("/ShowImages/") + PostedFile.FileName;
            PostedFile.PostedFile.SaveAs(imagePath);

        }

        public ActionResult SetFileUpload()
        {
            ls = UploadHelper.files;
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName] as HttpPostedFileBase;
                UploadFileInfo finfo = new UploadFileInfo();
                finfo.FileName = Path.GetFileName(file.FileName);
                finfo.PostedFile = file;
                ls.Add(finfo);
            }
            UploadHelper.files = ls;
            return null;
        }
        #endregion
    }
}
