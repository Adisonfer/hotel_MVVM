using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace hotel_MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private List<RoomModel> _rooms;
        private readonly IRoomService _roomService;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<RoomModel> Rooms
        {
            get => ConvertDataRoomView(_roomService.GetAllRooms());
            set
            {
                if (!Set(ref _rooms, value)) return;
            }
        }

        public MainViewModel(IRoomService roomService)
        {
            _roomService = roomService;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        private List<RoomModel> ConvertDataRoomView(List<RoomDTO> rooms)
        {
            return rooms.Select(i => new RoomModel(i)).ToList();
        }
    }
}
