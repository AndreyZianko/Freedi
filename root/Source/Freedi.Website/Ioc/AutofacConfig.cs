using Autofac;
using Autofac.Integration.Mvc;
using Freedi.Logic.Infrastructure;
using Freedi.Logic.loc;
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
            var builder = AutofacLogicConfig.ConfigureLogicContainer();
            builder.RegisterModule(new LogicModules());
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
             .InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}