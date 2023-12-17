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
        public string PhotoName { get; set; }
        public string Capacity { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }

        public RoomModel(RoomDTO room)
        {
            string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            RoomName = room.RoomName;
            PhotoName = imagesFolder + '/' + room.PhotoName;
            Capacity = "Количество мест: " + room.Capacity.ToString();
            Price = "Стоимость: " + room.Price.ToString() + "$";
            Description = room.Description;
        }
    }
}
