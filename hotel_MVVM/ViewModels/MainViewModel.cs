using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Windows;

namespace hotel_MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private Window _currentWindow;
        private List<RoomDTO> rooms;
        private readonly IRoomService _roomService;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<RoomDTO> Rooms
        {
            get => _roomService.GetAllRooms();
            set
            {
                if (!Set(ref rooms, value)) return;
            }
        }

        public MainViewModel(Window window, IRoomService roomService)
        {
            _roomService = roomService;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            _currentWindow = window;
        }
    }
}
