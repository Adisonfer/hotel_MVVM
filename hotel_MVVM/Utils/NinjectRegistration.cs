using DAL.Repository;
using BLL.Services;
using Intarfaces.Repository;
using Interfaces.Services;
using Ninject.Modules;

namespace hotel_MVVM.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoomService>().To<RoomService>();
        }
    }
}
