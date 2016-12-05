using BinaryDad.Services;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace BinaryDad.Web.Site.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public ContentService ContentService { get; set; }

        protected override void Dispose(bool disposing)
        {
            ContentService.Dispose();

            base.Dispose(disposing);
        }
    }
}