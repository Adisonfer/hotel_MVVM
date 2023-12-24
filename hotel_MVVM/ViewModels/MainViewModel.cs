using BLL.Services;
using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using hotel_MVVM.Views;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace hotel_MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private List<RoomModel> _rooms;
        private readonly IRoomService _roomService;
        private readonly IClientService _clientService;
        private readonly MainWindow _wnd;
        private ICommand _bookCommand;
        private ICommand _searchCommand;
        private int _roomCapacity;

        public int RoomCapacity
        {
            get => _roomCapacity;
            set
            {
                if (!Set(ref _roomCapacity, value)) return;
            }
        }

        public ICommand BookCommand
        {
            get { return _bookCommand; }
            set
            {
                if (!Set(ref _bookCommand, value)) return;
            }
        }

        public ICommand SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                if (!Set(ref _searchCommand, value)) return;
            }
        }

        private DateTime _checkInDate {  get; set; }
        private DateTime _checkOutDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<RoomModel> Rooms
        {
            get => _rooms;
            set
            {
                if (!Set(ref _rooms, value)) return;
            }
        }

        private ICommand _openProfileCommand;
        public ICommand OpenProfileCommand
        {
            get { return _openProfileCommand ?? (_openProfileCommand = new RelayCommand(openProfileWindow)); }
        }

        public MainViewModel(MainWindow wnd, IRoomService roomService, IClientService clientService)
        {
            _roomService = roomService;
            _clientService = clientService;
            StartDate = DateTime.Now.AddDays(1).Date;
            _checkInDate = StartDate;
            EndDate = DateTime.Now.AddDays(2).Date;
            _checkOutDate = EndDate;
            BookCommand = new RelayCommand(OnBook);
            SearchCommand = new RelayCommand(SearchRooms);
            _wnd = wnd;
        }

        private List<RoomModel> ConvertDataRoomView(List<RoomDTO> rooms)
        {
            return rooms.Select(i => new RoomModel(i)).ToList();
        }

        private void OnBook(object parameter)
        {
            int roomId = (int)parameter;
       
            BookingWindow bookingWindow = new BookingWindow(UpdateRooms, _checkInDate, _checkOutDate, roomId, _clientService);
            bookingWindow.Owner = _wnd;
            bookingWindow.ShowDialog();
        }

        private void UpdateRooms()
        {
            Rooms = ConvertDataRoomView(_roomService.GetFreeRooms(StartDate, EndDate, RoomCapacity));
        }

        private void SearchRooms(object parameter)
        {
            _checkInDate = StartDate;
            _checkOutDate = EndDate;
            if (!checkDate(StartDate, EndDate))
            {
                MessageBox.Show("Вы не можете забронировать номер на прошедшие даты или на сегодняшний день.");
                return;
            }
            UpdateRooms();
        }

        private bool checkDate(DateTime checkInDate, DateTime checkOutDate)
        {
            if (DateTime.Now >= checkInDate || DateTime.Now > checkOutDate ||
                checkInDate >= checkOutDate || (int)(checkOutDate - checkInDate).TotalDays > 30)
                return false;
            return true;
        }

        private void openProfileWindow(object parameter)
        {
            _wnd.OpenProfileWindow();
        }
    }
}
