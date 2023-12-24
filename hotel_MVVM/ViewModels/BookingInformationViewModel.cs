using hotel_MVVM.ViewModels.Base;
using hotel_MVVM.Views;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_MVVM.ViewModels
{
    public class BookingInformationViewModel : ViewModel
    {
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;
        private readonly IAdditionService _additionService;
        private readonly IBookingAddition _bookingAdditionService;
        private readonly IClientService _clientService;

        private DateTime _checkInDate;
        private DateTime _checkOutDate;

        private List<AdditionDTO> _additions = new List<AdditionDTO>();

        private RoomDTO _room;
        private BookingDTO _booking;
        private List<BookingAdditionDTO> _bookingAdditions;

        private string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

        private double? _roomPrice;

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

        private string _status;
        public string Status
        {
            get => $"Статус бронирования: {_status}";
        }

        public BookingInformationViewModel(IRoomService roomService, IBookingService bookingService,
            IBookingAddition bookingAddition, IAdditionService additionService ,
            IPaymentStatusService statusService, int booking_id) 
        {
            _booking = bookingService.GetBooking(booking_id);
            _roomPrice = _booking.Price;
            _room = roomService.GetRoom(_booking.RoomID);
            _checkInDate = _booking.CheckInDate;
            _checkOutDate = _booking.CheckOutDate;
            _bookingAdditions = bookingAddition.GetBookingServices(booking_id);

            foreach (var item in _bookingAdditions)
            {
                _additions.Add(additionService.GetAddition(item.AdditionID));
            }
            _status = statusService.GetPaymentStatus(_booking.PaymentStatusID).StatusName;
        }
    }
}
