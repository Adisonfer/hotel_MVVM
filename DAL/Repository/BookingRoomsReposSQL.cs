using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookingRoomsReposSQL : IBookingRooms
    {
        private DataContext db;
        public BookingRoomsReposSQL(DataContext db)
        {
            this.db = db;
        }

        public List<BookingRoomReport> GetBookingRooms(int id_client)
        {
            var bookingRooms = from room in db.Room
                               join booking in db.Booking
                               on room.ID equals booking.RoomID
                               where booking.ClientID == id_client
                               select new BookingRoomReport
                               {
                                   RoomID = room.ID,
                                   RoomName = room.RoomName,
                                   Capacity = room.Capacity,
                                   Price = room.Price,
                                   PhotoName = room.PhotoName,
                                   BookingId = booking.ID
                               };

            return bookingRooms.ToList();
        }
    }
}
