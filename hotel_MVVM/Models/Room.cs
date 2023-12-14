using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_MVVM.Models
{
    public class RoomModel
    {
        public string RoomName { get; set; }
        public string Photo_Path { get; set; }
        public string NumberPlaces { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

        public RoomModel(RoomDTO room)
        {
            string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            RoomName = room.RoomName;
            Photo_Path = imagesFolder + '/' + room.Photo_Path;
            NumberPlaces = room.NumberPlaces.ToString();
            Price = room.Price.ToString();
            Description = room.Description;
        }
    }
}
