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
        private string connectionString;
        public ManagerModule(string connection)
        {
            connectionString = connection;
        }
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<EFUnitOfWork>()
       .As<IUnitOfWork>()
       .WithParameter("connection", new EFUnitOfWork(connectionString)).InstancePerRequest();

        }

      
      
    }
}
