using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class BookingAdminReport
    {
        public string RoomName { get; set; }
        public int? Capacity { get; set; }
        public double? Price { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BookingId { get; set; }
        public int PaymentStatusID { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
    }
}
