using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_MVVM.Models
{
    public class BookingAdminModel
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
        public string StatusName { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public BookingAdminModel(BookingAdminReport b, List<PaymentStatusDTO> paymentStatuses)
        {
            FirstName = b.FirstName;
            LastName = b.LastName;
            BookingId = b.BookingId;
            PaymentStatusID = b.PaymentStatusID;
            RoomName = b.RoomName;
            Capacity = b.Capacity;
            Price = b.Price;
            CheckInDate = b.CheckInDate;
            CheckOutDate = b.CheckOutDate;
            RoomId = b.RoomId;
            ClientId = b.ClientId;
            StatusName = paymentStatuses.Where(i => i.ID == b.PaymentStatusID).FirstOrDefault().StatusName;
        }
    }
}
