using Interfaces.DTO;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IBookingService
    {
        List<BookingDTO> GetAllBooking();
        BookingDTO GetBooking(int id);
    }
}
