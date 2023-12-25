using Interfaces.DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingAdminReportReposSQL : IBookingAdminReportRepository
    {
        private DataContext db;
        public BookingAdminReportReposSQL(DataContext db)
        {
            this.db = db;
        }

        public List<BookingAdminReport> GetBookingAdminReports()
        {
            var bookingRooms = from room in db.Room
                               join booking in db.Booking on room.ID equals booking.RoomID
                               join client in db.Client on booking.ClientID equals client.ID
                               join user in db.User on client.UserID equals user.ID
                               select new BookingAdminReport
                               {
                                   RoomName = room.RoomName,
                                   Capacity = room.Capacity,
                                   Price = booking.Price,
                                   BookingId = booking.ID,
                                   CheckInDate = booking.CheckInDate,
                                   CheckOutDate = booking.CheckOutDate,
                                   FirstName = user.FirstName,
                                   LastName = user.LastName,
                                   PaymentStatusID = booking.PaymentStatusID,
                                   RoomId = booking.RoomID,
                                   ClientId = booking.ClientID,
                               };

            return bookingRooms.ToList();
        }
    }
}
