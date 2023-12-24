using DomainModel;
using Intarfaces.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookingService : IBookingService
    {
        private IDbRepos db;
        public BookingService(IDbRepos db)
        {
            this.db = db;
        }

        public int Create(BookingDTO booking)
        {
            if (booking.CheckInDate >= booking.CheckOutDate
                || booking.CheckInDate < DateTime.Now)
                return -1;

            Booking newBooking = new Booking
            {
                ClientID = booking.ClientID,
                RoomID = booking.RoomID,
                Price = booking.Price,
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                PaymentStatusID = booking.PaymentStatusID,
                AdministratorID = booking.AdministratorID,
            };
            db.Bookings.Create(newBooking);
            db.Save();
            return newBooking.ID;
        }

        public List<BookingDTO> GetAllBooking()
        {
            throw new NotImplementedException();
        }

        public BookingDTO GetBooking(int id)
        {
            return new BookingDTO(db.Bookings.GetItem(id));
        }

        public double GetBookingPrice(DateTime checkInDate, DateTime checkOutDate, double price, int[] services_id)
        {

            int numberOfNights = (int)(checkOutDate - checkInDate).TotalDays;

            double totalNightPrice = numberOfNights * price;

            // Рассчитываем стоимость дополнительных услуг
            double totalAdditionalServicePrice = GetTotalAdditionalServicePrice(services_id);

            return totalAdditionalServicePrice * numberOfNights + totalNightPrice;
        }

        public void Update(BookingDTO dto)
        {
            throw new NotImplementedException();
        }

        private double GetTotalAdditionalServicePrice(int[] services_id)
        {
            double total = 0;
            foreach(int id in services_id)
            {
                var service = db.Additions.GetItem(id);
                if (service == null)
                    continue;
                total += service.Price;
            }
            return total;
        }
    }
}
