using Autofac;
using Autofac.Integration.Mvc;
using Freedi.Logic.Infrastructure;
using System;
using System.Collections.Generic;
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
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

            //builder.RegisterModule(new ManagerModule("DefaultConnection"));
            //builder.RegisterModule(new OrderModule());
            var domainAssemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            builder.RegisterAssemblyModules(domainAssemblies.ToArray());
            builder.RegisterModule<AutofacWebTypesModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}