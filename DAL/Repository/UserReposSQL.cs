using DomainModel;
using Intarfaces.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DAL.Repository
{
    public class UserReposSQL : IRepository<User>
    {
        private DataContext db;
        public UserReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetItem(int id)
        {
            return db.User.Find(id);
        }

        public List<User> GetList()
        {
            return db.User.ToList();
        }

        public void Update(User item)
        {
            throw new System.NotImplementedException();
        }
    }
}
