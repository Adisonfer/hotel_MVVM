using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpdateData()
        {
            Rooms = ConvertDataRoomView(_roomService.GetAllRooms());
        }

        private List<RoomModel> ConvertDataRoomView(List<RoomDTO> rooms)
        {
            return rooms.Select(i => new RoomModel(i)).ToList();
        }
    }
}
