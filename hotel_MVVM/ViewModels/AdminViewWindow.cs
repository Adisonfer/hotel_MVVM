using hotel_MVVM.Infrastructure.Services.Interfaces;
using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class AdminViewWindow : ViewModel
    {
        private IRoomService _roomService;
        private List<RoomModel> _rooms;

        public ICommand OpenCreateRoomCommand { get; }

        public AdminViewWindow(IRoomService roomService) {
            _roomService = roomService;
        }

        public List<RoomModel> Rooms
        {
            get => ConvertDataRoomView(_roomService.GetAllRooms());
            set
            {
                if (!Set(ref _rooms, value)) return;
            }
        }

        private List<RoomModel> ConvertDataRoomView(List<RoomDTO> rooms)
        {
            return rooms.Select(i => new RoomModel
            {
                RoomName = i.RoomName.ToString(),
                Price = i.Price.ToString() + "$",
                NumberPlaces = "Place: " + i.NumberPlaces,
                ImagePath = i.ImagePath
            }).ToList();
        }
    }
}
