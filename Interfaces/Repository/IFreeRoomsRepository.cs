using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IFreeRoomsRepository
    {
        List<RoomDTO> GetFreeRooms(DateTime checkInDate, DateTime checkOutDate, int capacity);
    }
}
