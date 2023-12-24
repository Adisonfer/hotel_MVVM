using Interfaces.DTO;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class FreeRoomsReposSQL : IFreeRoomsRepository
    {
        private DataContext db;
        public FreeRoomsReposSQL(DataContext db)
        {
            this.db = db;
        }

        public List<RoomDTO> GetFreeRooms(DateTime checkInDate, DateTime checkOutDate, int capacity)
        {
            var freeRooms = from room in db.Room
                            where room.Capacity == capacity && room.Availability == true &&
                                  !db.Booking.Any(booking =>
                                      booking.RoomID == room.ID &&
                                      ((
                                          (checkInDate >= booking.CheckInDate && checkInDate <= booking.CheckOutDate) ||
                                          (checkOutDate >= booking.CheckInDate && checkOutDate <= booking.CheckOutDate)
                                      ) ||
                                      booking.PaymentStatusID == 3)
                                  )
                            select new RoomDTO
                            {
                                ID = room.ID,
                                RoomName = room.RoomName,
                                Capacity = room.Capacity,
                                Price = room.Price,
                                Description = room.Description,
                                PhotoName = room.PhotoName,
                                Availability = room.Availability,
                            };

            return freeRooms.ToList();
        }

    }
}
