using Interfaces.DTO;
using System;
using System.Collections.Generic;

namespace Interfaces.Services
{
    internal interface IFreeRooms
    {
        List<RoomDTO> GetFreeRooms(DateTime checkInDate, DateTime checkOutDate);
    }
}
