using DoctorsView.API;
using DoctorsView.ViewModels;
using Ninject.Modules;

namespace DoctorsView
{
    class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IQueueServiceAPI>().To<QueueServiceAPI>().InSingletonScope(); // Reuse same storage every time

            Bind<DoctorsWindowVM>().ToSelf().InTransientScope(); // Create new instance every time
        }
    }
}
