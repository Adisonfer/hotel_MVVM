using DomainModel;
using Intarfaces.Repository;
using Interfaces.Repository;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private DataContext db;
        private UserReposSQL userRepos;
        private RoomReposSQL roomRepos;
        private ClientReposSQL clientRepos;
        private AdminReposSQL adminRepos;
        private BookingReposSQL bookingRepos;
        private ServiceReposSQL serviceRepos;
        private FreeRoomsReposSQL freeRoomsRepos;

        public DbReposSQL()
        {
            db = new DataContext();
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepos == null)
                    userRepos = new UserReposSQL(db);
                return userRepos;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                if (roomRepos == null)
                    roomRepos = new RoomReposSQL(db);
                return roomRepos;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepos == null)
                    clientRepos = new ClientReposSQL(db);
                return clientRepos;
            }
        }

        public IRepository<Administrator> Administrators
        {
            get
            {
                if (adminRepos == null)
                    adminRepos = new AdminReposSQL(db);
                return adminRepos;
            }
        }

        public IRepository<Booking> Bookings
        {
            get
            {
                if (bookingRepos == null)
                    bookingRepos = new BookingReposSQL(db);
                return bookingRepos;
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                if (serviceRepos == null)
                    serviceRepos = new ServiceReposSQL(db);
                return serviceRepos;
            }
        }

        public IRepository<BookingService> BookingsServices => throw new System.NotImplementedException();

        public IFreeRoomsRepository FreeRooms
        {

            get
            {
                if (freeRoomsRepos == null)
                    freeRoomsRepos = new FreeRoomsReposSQL(db);
                return freeRoomsRepos;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
