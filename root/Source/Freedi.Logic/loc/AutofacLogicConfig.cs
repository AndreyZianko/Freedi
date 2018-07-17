using Autofac;
using Autofac.Integration.Mvc;
using Freedi.DataProvider.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Freedi.Logic.loc
{
    public class AutofacLogicConfig
    {
        public  static ContainerBuilder ConfigureLogicContainer()
        {
            var builder = new ContainerBuilder();
    
            
            builder.RegisterModule(new DataProviderModule());
            return builder;
            
        }
    }
}
