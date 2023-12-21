using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AdditionReposSQL : IRepository<Addition>
    {
        private DataContext db;
        public AdditionReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(Addition item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Addition GetItem(int id)
        {
            return db.Addition.Find(id);
        }

        public List<Addition> GetList()
        {
            return db.Addition.ToList();
        }

        public void Update(Addition item)
        {
            throw new NotImplementedException();
        }
    }
}
