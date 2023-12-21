using DomainModel;
using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingAdditionService : IBookingAddition
    {
        private IDbRepos db;
        public BookingAdditionService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateBookingService(BookingAdditionDTO dto)
        {
            db.BookingAdditions.Create(new DomainModel.BookingAddition { AdditionID = dto.AdditionID, BookingID = dto.BookingID });
            db.Save();
        }

        public List<BookingAdditionDTO> GetBookingServices(int id)
        {
            return db.BookingAdditions.GetList().Select(i => new BookingAdditionDTO(i)).Where(i => i.ID == id).ToList();
        }
    }
}
