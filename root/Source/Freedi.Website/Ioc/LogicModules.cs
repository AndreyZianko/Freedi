using Autofac;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;

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