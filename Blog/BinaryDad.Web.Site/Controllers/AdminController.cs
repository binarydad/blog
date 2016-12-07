using BinaryDad.Models;
using BinaryDad.Web.Site.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BinaryDad.Web.Site.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        #region Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ActionName("Login")]
        [AllowAnonymous]
        public ActionResult LoginPost(LoginViewModel model)
        {
            if (model.Username == "binarydad" && model.Password == "thisisonlytemporaryipromise")
            {
                FormsAuthentication.RedirectFromLoginPage(model.Username, true);
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/");
        }

        #endregion

        #region Edit

        public ActionResult Edit(string path = "")
        {
            var content = ContentService.Get<Content>(path);

            return View(content);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateInput(false)]
        public async Task<ActionResult> EditPost(TextContent content)
        {
            content = await ContentService.Save(content);

            return RedirectToRoute("Admin", new { path = content.Path, action = "edit" });
        }

        #endregion

        #region Create

        public ActionResult Create(ContentType type)
        {
            if (type == ContentType.Page)
            {
                return View(new Page());
            }

            if (type == ContentType.BlogEntry)
            {
                return View(new BlogEntry());
            }

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateInput(false)]
        public async Task<ActionResult> CreatePost(TextContent content)
        {
            var newContent = await ContentService.Create(content);

            if (newContent != null)
            {
                return RedirectToRoute("Admin", new { path = content.Path, action = "edit" });
            }

            ModelState.AddModelError("Invalid", "Could not create content");

            return View(content);
        }

        #endregion

        #region Delete

        public async Task<ActionResult> Delete(string path, string returnUrl = "~/")
        {
            await ContentService.Delete(path);

            return Redirect(returnUrl);
        }

        #endregion

        #region Upload

        public ActionResult Upload()
        {
            var files = ContentService.Get<File>();

            return View(files);
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    using (var stream = new System.IO.MemoryStream())
                    {
                        await file.InputStream.CopyToAsync(stream);

                        var upload = await ContentService.Create(new File
                        {
                            Title = file.FileName,
                            Path = file.FileName,
                            MimeType = file.ContentType,
                            Data = stream.ToArray()
                        });
                    }
                }
            }

            return RedirectToAction("upload");
        }

        #endregion

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var result = filterContext.Result as ViewResult;

            if (result != null && result.Model != null)
            {
                if (result.Model is Page)
                {
                    var model = result.Model as Page;

                    ViewBag.Parents = ContentService
                        .Get<Page>()
                        .Where(p => p.ID != model.ID);
                }

                if (result.Model is TextContent)
                {
                    ViewBag.Files = ContentService.Get<File>();
                }
            }
        }
    }
}
