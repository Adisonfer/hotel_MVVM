using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class BookingRoomReport
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int? Capacity { get; set; }
        public double Price { get; set; }
        //public string Description { get; set; }
        public string PhotoName { get; set; }
        public int BookingId { get; set; }
    }
}
