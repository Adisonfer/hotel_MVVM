using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
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
        public List<RoomDTO> GetAllRooms()
        {
            return db.Rooms.GetList().Select(i => new RoomDTO(i)).ToList();
        }
        public void Save()
        {
            db.Save();
        }
    }
}
