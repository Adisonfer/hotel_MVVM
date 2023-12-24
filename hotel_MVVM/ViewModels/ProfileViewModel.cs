using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using hotel_MVVM.Views;
using Interfaces.DTO;
using Interfaces.Services;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class ProfileViewModel : ViewModel
    {
        private ProfileWindow _wnd;
        private IRoomService _roomService;
        private IUserService _userService;
        private IClientService _clientService;

        private ICommand _back;
        public ICommand Back
        {
            get { return _back ?? (_back = new RelayCommand(BackWindow)); }
        }

        private ICommand _signOut;
        public ICommand SignOut
        {
            get { return _signOut ?? (_signOut = new RelayCommand(ToLoginWindow)); }
        }

        private ICommand _informBooking;
        public ICommand InformationCommand
        {
            get { return _informBooking ?? (_informBooking = new RelayCommand(InformBookingWindow)); }
        }

        private UserDTO _user;
        private ClientDTO _client;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;

        public string FullName {get => $"{_firstName} {_lastName}"; }
        public string PhoneNumber {get => _phoneNumber;}
        public string Email { get => _email;}

        private List<RoomModel> _rooms;
        public List<RoomModel> Rooms
        {
            get => _rooms;
            set
            {
                if (!Set(ref _rooms, value)) return;
            }
        }

        public ProfileViewModel(ProfileWindow wnd, IRoomService roomService, IClientService clientService,
            IUserService userService)
        {
            _wnd = wnd;
            _roomService = roomService;
            _userService = userService;
            _clientService = clientService;

            _client = clientService.CurrentClient;
            _user = userService.GetUser(_client.UserID);
            _firstName = _user.FirstName; _lastName = _user.LastName;
            _phoneNumber = _client.PhoneNumber;
            _email = _client.EmailAddress;

            UpdateBookingRooms();
        }

        private void BackWindow(object param)
        {
            _wnd.CloseWnd();
        }

        private void ToLoginWindow(object param)
        {
            _wnd.ToLoginWnd();
        }

        private void InformBookingWindow(object param)
        {
            int bookingId = (int)param;

            BookingInformationWindow bookingWindow = new BookingInformationWindow(bookingId, _roomService);
            bookingWindow.Owner = _wnd;
            bookingWindow.ShowDialog();
        }

        private List<RoomModel> ConvertDataRoomView(List<BookingRoomReport> rooms)
        {
            return rooms.Select(i => new RoomModel(i)).ToList();
        }

        private void UpdateBookingRooms()
        {
            Rooms = ConvertDataRoomView(_roomService.GetBookingRooms(_client.ID));
        }
    }
}
