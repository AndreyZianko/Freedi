using Autofac;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freedi.Website.Ioc
{
    public class LogicModules : Module
    {
      
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderManager>()
                   .As<IOrderManager>().InstancePerRequest();
            builder.RegisterType<GoodsManager>()
                   .As<IGoodsManager>().InstancePerRequest();


        }
    }
}