using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private DataContext db;
        private UserReposSQL userRepos;
        private RoomReposSQL roomRepos;

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
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
