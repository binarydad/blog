using BinaryDad.Models;
using BinaryDad.Web.Site.Models;
using System.Linq;
using System.Web.Mvc;

namespace BinaryDad.Web.Site.Controllers
{
    public class ContentController : BaseController
    {
        public ActionResult Home()
        {
            var model = new HomeViewModel
            {
                Page = ContentService.Get<Page>("home"),
                Entries = ContentService.Get<BlogEntry>().ToList()
            };

            return View(model);
        }

        [OutputCache(Duration = 60)]
        public FileResult File(string path)
        {
            var file = ContentService.Get<File>(path);

            return File(file.Data, file.MimeType);
        }

        public ActionResult Page(string path)
        {
            var content = ContentService.Get<Content>(path);

            return View(content);
        }

        #region Child Actions

        [ChildActionOnly]
        [Route("MainNavigation")]
        public ActionResult MainNavigation()
        {
            var navPages = ContentService.Get<Page>();

            return PartialView(navPages);
        }
        
        #endregion
    }
}