using System.Web;

namespace ShawApplication.API.Helper
{
    public class UploadFileInfo
    {
        public string FileName { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }
    }
}