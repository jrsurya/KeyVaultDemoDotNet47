using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using StorageAccountDemoDotNet48.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StorageAccountDemoDotNet48.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task< ActionResult> About()
        {
           
           await new StorageAccountHelper().CreateBlockBlobAsync("test-blob");
            ViewBag.Message = "Blob has been created success fully.";
            return View();
        }

        public async Task<ActionResult> Download()
        {

            ViewBag.Message = await new StorageAccountHelper().DownloadBlockBlobAsync("test-blob");
           // ViewBag.Message = "Blob has been created success fully.";
            return Content(ViewBag.Message);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}