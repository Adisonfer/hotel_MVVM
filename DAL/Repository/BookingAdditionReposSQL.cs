using DomainModel;
using Intarfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingAdditionReposSQL : IRepository<BookingAddition>
    {
        private DataContext db;
        public BookingAdditionReposSQL(DataContext db)
        {
            this.db = db;
        }

        public void Create(BookingAddition item)
        {
            db.BookingAddition.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BookingAddition GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookingAddition> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(BookingAddition item)
        {
            throw new NotImplementedException();
        }
    }
}
