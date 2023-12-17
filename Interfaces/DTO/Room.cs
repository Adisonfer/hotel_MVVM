using DomainModel;

namespace Interfaces.DTO
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public int? Capacity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string PhotoName { get; set; }
        public bool? Availability { get; set; }

        public RoomDTO() { }
        public RoomDTO(Room room)
        {
            ID = room.ID;
            RoomName = room.RoomName;
            Capacity = room.Capacity;
            Price = room.Price;
            Description = room.Description;
            PhotoName = room.PhotoName;
            Availability = room.Availability;
        }
    }
}
