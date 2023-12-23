using Interfaces.DTO;
using System;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IBookingService
    {
        int Create(BookingDTO dto);
        void Update(BookingDTO dto);
        List<BookingDTO> GetAllBooking();
        BookingDTO GetBooking(int id);
        double GetBookingPrice(DateTime checkInDate, DateTime checkOutDate, double price, int[] services_id);
    }
}
