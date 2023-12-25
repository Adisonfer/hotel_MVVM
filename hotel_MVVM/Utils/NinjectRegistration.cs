using BLL.Services;
using Interfaces.Repository;
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
            Bind<IBookingService>().To<BookingService>();
            Bind<IAdditionService>().To<AdditionService>();
            Bind<IBookingAddition>().To<BookingAdditionService>();
            Bind<IPaymentStatusService>().To<PaymentStatusService>();
        }
    }
}
