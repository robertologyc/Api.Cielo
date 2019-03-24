using System.Web.Mvc;
using System.Web.Routing;
using Api.Cielo.Lio.Web.Ioc;

namespace Api.Cielo.Lio.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SimpleInjectorContainer.Register();
        }
    }
}
