using Autofac;
using Freedi.Logic.Interfaces;
using Freedi.Logic.Managers;

namespace Freedi.Logic.Infrastructure
{
    public class ManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerRequest();
            builder.RegisterType<PhotoManager>().As<IPhotoManager>().InstancePerRequest();
        }
    }
}