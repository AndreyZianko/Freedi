using Autofac;
using Freedi.DataProvider.Infrastructure;

namespace Freedi.Logic.loc
{
    public class AutofacLogicConfig
    {
        public static ContainerBuilder ConfigureLogicContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DataProviderModule());
            return builder;

        }
    }
}
