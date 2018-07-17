using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Repositories;

namespace Freedi.Logic.Infrastructure
{
    public class ManagerModule : Module
    {
      
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

        }

      
      
    }
}
