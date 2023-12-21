using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingServiceReposSQL : IRepository<BookingService>
    {
        private DataContext db;
        public BookingServiceReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(BookingService item)
        {
            db.BookingService.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BookingService GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookingService> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(BookingService item)
        {
            throw new NotImplementedException();
        }
    }
}
