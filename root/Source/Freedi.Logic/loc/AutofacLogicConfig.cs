using Autofac;
using Freedi.DataProvider.Infrastructure;
using Freedi.Logic.Infrastructure;

namespace Freedi.Logic.loc
{
    public class AutofacLogicConfig
    {
        public static ContainerBuilder ConfigureLogicContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataProviderModule());
            builder.RegisterModule(new ManagerModule());

            return builder;

        }
    }
}
