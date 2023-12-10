using DomainModel;
using Intarfaces.Repository;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private DataContext db;
        private UserReposSQL userRepos;
        private RoomReposSQL roomRepos;
        private ClientReposSQL clientRepos;
        private AdminReposSQL adminRepos;

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
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
