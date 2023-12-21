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


        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IServiceService _serviceService;
        private readonly IServiceBookingService _serviceBookingService;

        private readonly DateTime _checkInDate;
        private readonly DateTime _checkOutDate;

        private readonly List<ServiceDTO> _services;
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
            get => $"Внимание! Время заезда и выезда - 12:00 UTC +3 \n Описание: {_room.Description}";
        }
        public List<ServiceDTO> Services
        {
            get => _services;
        }

        public BookingViewModel(IRoomService roomService, IBookingService bookingService,
            IServiceService serviceService, IServiceBookingService serviceBookingService,
            DateTime checkInDate, DateTime checkOutDate, int roomId) {
            _serviceService = serviceService;
            _serviceBookingService = serviceBookingService;
            _roomService = roomService;
            _room = _roomService.GetRoom(roomId);

            _bookingService = bookingService;
            _roomPrice = _bookingService.GetBookingPrice(checkInDate, checkOutDate, _room.Price, _services_id) ;

            _services = _serviceService.GetServices();

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

    }
}
