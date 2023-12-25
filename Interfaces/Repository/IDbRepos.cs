using DomainModel;
using Interfaces.Repository;

namespace Intarfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<User> Users { get; }
        IRepository<Room> Rooms { get; }
        IRepository<Client> Clients { get; }
        IRepository<Administrator> Administrators { get; }
        IRepository<Booking> Bookings { get; }
        IRepository<Addition> Additions { get; }
        IRepository<BookingAddition> BookingAdditions { get; }
        IFreeRoomsRepository FreeRooms { get; }
        IBookingRooms BookingRooms { get; }
        IRepository<PaymentStatus> PaymentStatus { get; }
        IBookingAdminReportRepository BookingAdminReports { get; }

        void Save();
    }
}
