using Interfaces.DTO;
using System;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IRoomService
    {
        List<RoomDTO> GetAllRooms();
        List<RoomDTO> GetFreeRooms(DateTime checkInDate, DateTime chechOutDate, int capacity);
        List<BookingRoomReport> GetBookingRooms(int id_client);
        void CreateRoom(RoomDTO roomDTO);
        RoomDTO GetRoom(int roomId);
    }
}
