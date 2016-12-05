using BinaryDad.Data.Repositories;
using BinaryDad.Models;
using Microsoft.Practices.Unity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace BinaryDad.Web.Site
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new UnityContainer();

            container.RegisterType<IContentRepository, EFContentRepository>();

            var unityResolver = new UnityDependencyResolver(container);

            DependencyResolver.SetResolver(unityResolver);
            GlobalConfiguration.Configuration.DependencyResolver = unityResolver;

            ModelBinders.Binders.Add(typeof(TextContent), new BlogModelBinder());
        }
    }
}
