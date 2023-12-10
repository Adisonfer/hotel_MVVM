using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class AdminReposSQL : IRepository<Administrator>
    {
        private DataContext db;
        public AdminReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(Administrator item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Administrator GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<Administrator> GetList()
        {
            return db.Administrator.ToList();
        }

        public void Update(Administrator item)
        {
            throw new NotImplementedException();
        }
    }
}
