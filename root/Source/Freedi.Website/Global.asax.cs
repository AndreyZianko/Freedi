﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Freedi.Website.Ioc;

namespace Freedi.Website
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}