using Northwind.Entities.Concrete;
using Northwind.WebUI.Infrastructure;
using Northwind.WebUI.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            //Eğer biri senden Cart isterse onu Cartmodel binderdan al
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
