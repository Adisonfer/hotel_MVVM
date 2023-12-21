using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ServiceReposSQL : IRepository<Service>
    {
        private DataContext db;
        public ServiceReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(Service item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Service GetItem(int id)
        {
            return db.Service.Find(id);
        }

        public List<Service> GetList()
        {
            return db.Service.ToList();
        }

        public void Update(Service item)
        {
            throw new NotImplementedException();
        }
    }
}
