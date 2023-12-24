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
        private AdditionReposSQL serviceRepos;
        private FreeRoomsReposSQL freeRoomsRepos;
        private BookingAdditionReposSQL bookingAdditionRepos;
        private BookingRoomsReposSQL bookingRoomsReposSQL; 
        private PaymentStatusReposSQL paymentStatusRepos;

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

        public IRepository<Addition> Additions
        {
            get
            {
                if (serviceRepos == null)
                    serviceRepos = new AdditionReposSQL(db);
                return serviceRepos;
            }
        }

        public IRepository<BookingAddition> BookingAdditions
        {
            get
            {
                if (bookingAdditionRepos == null)
                    bookingAdditionRepos = new BookingAdditionReposSQL(db);
                return bookingAdditionRepos;
            }
        }

        public IFreeRoomsRepository FreeRooms
        {

            get
            {
                if (freeRoomsRepos == null)
                    freeRoomsRepos = new FreeRoomsReposSQL(db);
                return freeRoomsRepos;
            }
        }
        public IBookingRooms BookingRooms
        {
            get
            {
                if (bookingRoomsReposSQL == null)
                    bookingRoomsReposSQL = new BookingRoomsReposSQL(db);
                return bookingRoomsReposSQL;
            }
        }

        public IRepository<PaymentStatus> PaymentStatus
        {
            get
            {
                if (paymentStatusRepos == null)
                    paymentStatusRepos = new PaymentStatusReposSQL(db);
                return paymentStatusRepos;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
