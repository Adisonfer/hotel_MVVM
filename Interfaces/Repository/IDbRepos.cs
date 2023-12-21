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
        IRepository<Service> Services { get; }
        IRepository<BookingService> BookingsServices { get; }
        IFreeRoomsRepository FreeRooms { get; }

        void Save();
    }
}
