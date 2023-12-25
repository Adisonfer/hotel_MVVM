using BLL.Services;
using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.Models;
using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class AdminViewWindow : ViewModel
    {
        private IRoomService _roomService;
        private IBookingService _bookingService;
        private IPaymentStatusService _statusService;
        private List<RoomModel> _rooms;

        public ICommand OpenCreateRoomCommand { get; }

        public AdminViewWindow(IRoomService roomService, IBookingService bookingService, IPaymentStatusService statusService) {
            _roomService = roomService;
            _bookingService = bookingService;
            _statusService = statusService;
            _paymentStatuses = _statusService.GetAllPaymentStatuses();
            _bookings = _bookingService.GetAllBookingsReport().Select(i => new BookingAdminModel(i, _paymentStatuses)).ToList();
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


        private List<BookingAdminModel> _bookings;

        public List<BookingAdminModel> Bookings
        {
            get => _bookings;
            set
            {
                if (!Set(ref _bookings, value)) return;
                OnPropertyChanged(nameof(Bookings));
            }
        }

        private List<PaymentStatusDTO> _paymentStatuses;
        public List<PaymentStatusDTO> PaymentStatuses
        {
            get => _paymentStatuses;
            set
            {
                if (!Set(ref _paymentStatuses, value)) return;
            }
        }
        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(SaveChanges)); }
        }
        private void SaveChanges(object param)
        {
            foreach (var booking in Bookings)
            {
                BookingDTO bookingDTO = new BookingDTO();
                bookingDTO.ID = booking.BookingId;
                bookingDTO.CheckInDate = booking.CheckInDate;
                bookingDTO.CheckOutDate = booking.CheckOutDate;
                bookingDTO.RoomID = booking.RoomId;
                bookingDTO.Price = booking.Price;
                bookingDTO.PaymentStatusID = booking.PaymentStatusID;
                bookingDTO.ClientID = booking.ClientId;

                _bookingService.Update(bookingDTO);
            }

            MessageBox.Show("Изменения сохранены");
        }
    }
}
