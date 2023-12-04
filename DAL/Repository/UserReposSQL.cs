using DomainModel;
using Intarfaces.Repository;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public List<User> GetList()
        {
            throw new System.NotImplementedException();
        }

        public void Update(User item)
        {
            throw new System.NotImplementedException();
        }
    }
}
