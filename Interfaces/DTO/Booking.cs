using DomainModel;
using System;

namespace Interfaces.DTO
{
    public class BookingDTO
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? PaymentStatusID { get; set; }
        public int? AdministratorID { get; set; }

        public BookingDTO() { }
        public BookingDTO(Booking booking)
        {
            ID = booking.ID;
            ClientID = booking.ClientID;
            RoomID = booking.RoomID;
            CheckInDate = booking.CheckInDate;
            CheckOutDate = booking.CheckOutDate;
            PaymentStatusID = booking.PaymentStatusID;
            AdministratorID = booking.AdministratorID;
        }
    }
}
