using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace hotel_MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private Window _currentWindow;
        private ObservableCollection<Room> rooms;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                if (!Set(ref rooms, value)) return;
            }
        }

        public MainViewModel(Window window)
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            _currentWindow = window;
            Rooms = new ObservableCollection<Room>
            {
                new Room { RoomName = "Room 1 ывмывмвымвмвмв", ImagePath = "/Images/Rooms/room1.png", Place = 3 },
                new Room { RoomName = "Room 2", ImagePath = "/Images/Rooms/room1.png", Place = 4 },
                new Room { RoomName = "Room 3", ImagePath = "/Images/Rooms/room1.png", Place = 4 },
                new Room { RoomName = "Room 4", ImagePath = "/Images/Rooms/room1.png", Place = 4 },
                new Room { RoomName = "Room 5", ImagePath = "/Images/Rooms/room1.png", Place = 4 },
                new Room { RoomName = "Room 6", ImagePath = "/Images/Rooms/room1.png", Place = 4 },
            };
        }
    }
}
