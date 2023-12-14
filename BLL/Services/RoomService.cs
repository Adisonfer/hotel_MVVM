using DomainModel;
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

        public void CreateRoom(RoomDTO roomDTO)
        {
            db.Rooms.Create(new Room { 
                RoomName = roomDTO.RoomName, 
                Price = roomDTO.Price,
                Description = roomDTO.Description,
                NumberPlaces = roomDTO.NumberPlaces,
                Photo_Path = roomDTO.Photo_Path,
                Availability = true,
            });
            db.Save();
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
