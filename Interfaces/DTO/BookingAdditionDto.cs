using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class BookingAdditionDTO
    {
        public int ID { get; set; }
        public int AdditionID { get; set; }
        public int BookingID { get; set; }

        public BookingAdditionDTO() { }
        public BookingAdditionDTO(BookingAddition service)
        {
            ID = service.ID;
            AdditionID = service.AdditionID;
            BookingID = service.BookingID;
        }
    }
}
