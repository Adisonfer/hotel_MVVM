using DomainModel;

namespace Interfaces.DTO
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public int? NumberPlaces { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Photo_Id { get; set; }

        public RoomDTO() { }
        public RoomDTO(Room room)
        {
            ID = room.ID;
            RoomName = room.RoomName;
            NumberPlaces = room.NumberPlaces;
            Price = room.Price;
            Description = room.Description;
            Photo_Id = room.Photo_Id;
        }
    }
}
