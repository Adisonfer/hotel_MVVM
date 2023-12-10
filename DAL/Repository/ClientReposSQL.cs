using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ClientReposSQL : IRepository<Client>
    {
        private DataContext db;
        public ClientReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(Client item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Client GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetList()
        {
            return db.Client.ToList();
        }

        public void Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
