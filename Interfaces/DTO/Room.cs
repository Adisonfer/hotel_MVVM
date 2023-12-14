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
        public string Photo_Path { get; set; }
        public string ImagePath { get; set; } 
        public bool Availability { get; set; }

        public RoomDTO() { }
        public RoomDTO(Room room)
        {
            ID = room.ID;
            RoomName = room.RoomName;
            NumberPlaces = room.NumberPlaces;
            Price = room.Price;
            Description = room.Description;
            Photo_Path = room.Photo_Path;
            Availability = room.Availability;
        }
    }
}
