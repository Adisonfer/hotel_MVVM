using BLL.Services;
using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class BookingViewModel : ViewModel
    {
        private ICommand _toggleServiceCommand;
        public ICommand ToggleServiceCommand
        {
            get { return _toggleServiceCommand ?? (_toggleServiceCommand = new RelayCommand(ToggleService)); }
        }
        private ICommand _payCommand;
        public ICommand PayCommand
        {
            get { return _payCommand ?? (_payCommand = new RelayCommand(CreateBooking)); }
        }

        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IAdditionService _additionService;
        private readonly IBookingAddition _bookingAdditionService;
        private readonly IClientService _clientService;

        private readonly DateTime _checkInDate;
        private readonly DateTime _checkOutDate;

        private readonly List<AdditionDTO> _additions;
        private int[] _services_id = { };

        private RoomDTO _room;
        private string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

        private double _roomPrice;

        public string NameRoom
        {
            get => _room.RoomName;
        }
        public string Capacity
        {
            get => "Количество мест: " + _room.Capacity.ToString();

        }
        public string Date
        {
            get => "Дата проживания: " + _checkInDate.ToShortDateString() + " / " + _checkOutDate.ToShortDateString();
        }
        public string PhotoName
        {
            get => imagesFolder + '/' + _room.PhotoName;
        }
        public string Price
        {
            get => "Стоимость: " + _roomPrice.ToString() + "$";
        }
        public string Description
        {
            get => $"Кол-во дней: {(int)(_checkOutDate - _checkInDate).TotalDays}" +
                $"\n Внимание! Время заезда и выезда - 12:00 UTC +3 \n Описание: {_room.Description}";
        }
        public List<AdditionDTO> Additions
        {
            get => _additions;
        }

        public BookingViewModel(IRoomService roomService, IBookingService bookingService,
            IAdditionService additionService, IBookingAddition serviceBookingService, IClientService clientService,
            DateTime checkInDate, DateTime checkOutDate, int roomId) {
            _additionService = additionService;
            _bookingAdditionService = serviceBookingService;
            _roomService = roomService;
            _clientService = clientService;
            _room = _roomService.GetRoom(roomId);

            _bookingService = bookingService;
            _roomPrice = _bookingService.GetBookingPrice(checkInDate, checkOutDate, _room.Price, _services_id) ;

            _additions = _additionService.GetAdditions();

            _checkInDate = checkInDate;
            _checkOutDate = checkOutDate;

        }

        private void ToggleService(object parameter)
        {
            int serviceId = (int)parameter;

            if (_services_id.Contains(serviceId))
            {
                _services_id = _services_id.Where(id => id != serviceId).ToArray();
            }
            else
            {
                _services_id = _services_id.Concat(new[] { serviceId }).ToArray();
            }

            UpdateRoomPrice();
        }

        private void UpdateRoomPrice()
        {
            _roomPrice = _bookingService.GetBookingPrice(_checkInDate, _checkOutDate, _room.Price, _services_id);
            OnPropertyChanged(nameof(Price));
        }

        private void CreateBooking(object parameter)
        {
            BookingDTO booking = new BookingDTO();
            booking.CheckInDate = _checkInDate;
            booking.CheckOutDate = _checkOutDate;
            booking.Price = _roomPrice;
            booking.RoomID = _room.ID;
            booking.ClientID = _clientService.CurrentClient.ID;
            _bookingService.Create(booking);

            BookingAdditionDTO bookingService = new BookingAdditionDTO();
            foreach (var serviceId in _services_id)
            {
                //bookingService.BookingID = 
            }
        }
    }
}
