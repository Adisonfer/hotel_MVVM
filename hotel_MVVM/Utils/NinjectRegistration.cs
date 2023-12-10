using BLL.Services;
using Interfaces.Services;
using Ninject.Modules;

namespace hotel_MVVM.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoomService>().To<RoomService>();
            Bind<IAdminService>().To<AdminService>();
            Bind<IUserService>().To<UserService>();
            Bind<IClientService>().To<ClientService>();
        }
    }
}
