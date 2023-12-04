using Interfaces.DTO;
using System;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IRoomService
    {
        List<RoomDTO> GetAllRooms();
    }
}
