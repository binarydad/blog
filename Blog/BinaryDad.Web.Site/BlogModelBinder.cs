using BinaryDad.Models;
using System;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace BinaryDad.Web.Site
{
    public class BlogModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);

            if (model is TextContent)
            {
                var content = model as TextContent;
                var request = controllerContext.HttpContext.Request;

                #region BlogEntry

                if (RequestIs<BlogEntry>(request.Form))
                {
                    return new BlogEntry(content)
                    {
                        Summary = request.Form["Summary"]
                    };
                }

                #endregion

                #region Page

                if (RequestIs<Page>(request.Form))
                {
                    var page = new Page(content);
                    var parentId = request.Form["Parent.ID"];

                    if (!String.IsNullOrWhiteSpace(parentId))
                    {
                        page.Parent = new Page { ID = new Guid(parentId) };
                    }

                    return page;
                } 

                #endregion
            }

            return model;
        }

        static bool RequestIs<T>(NameValueCollection collection)
        {
            var type = typeof(T);

            return collection["type"].Equals(type.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}