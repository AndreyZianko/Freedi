using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Repositories;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;

namespace Freedi.Logic.Infrastructure
{
    public class ManagerModule : Module
    {
      
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerRequest();
        }

      
      
    }
}
