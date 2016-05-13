using System.Web.Mvc;
using System.Web.Routing;
using CadastroProdutos.Helpers;

namespace CadastroProdutos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(
                typeof(decimal), new DecimalModelBinder());
        }
    }
}
