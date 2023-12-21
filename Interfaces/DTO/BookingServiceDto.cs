using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class BookingServiceDTO
    {
        public int ID { get; set; }
        public int ServiceID { get; set; }
        public int BookingID { get; set; }

        public BookingServiceDTO() { }
        public BookingServiceDTO(BookingService service)
        {
            ID = service.ID;
            ServiceID = service.ServiceID;
            BookingID = service.BookingID;
        }
    }
}
