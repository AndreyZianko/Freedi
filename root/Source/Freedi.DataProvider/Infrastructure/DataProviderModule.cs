using Autofac;
using Freedi.DataProvider.Interfaces;
using Freedi.DataProvider.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Infrastructure
{
   public class DataProviderModule : Module
    {
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FreediContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<GoodRepository>().As<IGoodRepository>().InstancePerRequest();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerRequest();
            builder.RegisterType<ClientRepository>().As<IClientRepository>().InstancePerRequest();
            builder.RegisterType<PhotosRepository>().As<IPhotosRepository>().InstancePerRequest();
        }

    }
}
