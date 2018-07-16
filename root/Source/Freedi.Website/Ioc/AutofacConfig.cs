using Autofac;
using Autofac.Integration.Mvc;
using Freedi.Logic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace Freedi.Website.Ioc
{
    public class AutofacConfig
    {

      
        public static void ConfigureContainer()
        {
            var connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
   
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
             .InstancePerRequest();
            builder.RegisterModule(new ManagerModule(connection));
            builder.RegisterModule(new OrderModule());
           
            //var domainAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            //builder.RegisterAssemblyModules(domainAssemblies.ToArray());
            //builder.RegisterModule<AutofacWebTypesModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}