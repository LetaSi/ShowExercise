using System.Collections.Generic;
using System.Web;

namespace ShawApplication.API.Helper
{
    public class UploadHelper
    {
        public static List<UploadFileInfo> files
        {
            get
            {
                if (HttpContext.Current.Session["files"] != null)
                    return HttpContext.Current.Session["files"] as List<UploadFileInfo>;
                else
                    return new List<UploadFileInfo>();
            }
            set
            {
                HttpContext.Current.Session["files"] = value;
            }
        }
    }
}