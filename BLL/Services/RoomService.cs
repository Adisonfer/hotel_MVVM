using DomainModel;
using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class RoomService : IRoomService
    {
        private IDbRepos db;
        public RoomService(IDbRepos db)
        {
            this.db = db;
        }

        public void CreateRoom(RoomDTO roomDTO)
        {
            db.Rooms.Create(new Room { 
                RoomName = roomDTO.RoomName, 
                Price = roomDTO.Price,
                Description = roomDTO.Description,
                Capacity = roomDTO.Capacity,
                PhotoName = roomDTO.PhotoName,
                Availability = true,
            });
            db.Save();
        }

        public List<RoomDTO> GetAllRooms()
        {
            return db.Rooms.GetList().Select(i => new RoomDTO(i)).ToList();
        }

        public List<BookingRoomReport> GetBookingRooms(int id_client)
        {
            return db.BookingRooms.GetBookingRooms(id_client);
        }

        public List<RoomDTO> GetFreeRooms(DateTime checkInDate, DateTime chechOutDate, int capacity)
        {
            return db.FreeRooms.GetFreeRooms(checkInDate, chechOutDate, capacity).ToList();
        }

        public RoomDTO GetRoom(int roomId)
        {
            return new RoomDTO(db.Rooms.GetItem(roomId));
        }

        public void Save()
        {
            db.Save();
        }
    }
}
