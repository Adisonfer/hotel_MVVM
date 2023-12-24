using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PaymentStatusReposSQL : IRepository<PaymentStatus>
    {
        private DataContext db;
        public PaymentStatusReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(PaymentStatus item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentStatus GetItem(int id)
        {
            return db.PaymentStatus.Find(id);
        }

        public List<PaymentStatus> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentStatus item)
        {
            throw new NotImplementedException();
        }
    }
}
