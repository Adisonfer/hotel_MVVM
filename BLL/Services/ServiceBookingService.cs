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
    public class ServiceBookingService : IServiceBookingService
    {
        private IDbRepos db;
        public ServiceBookingService(IDbRepos db)
        {
            this.db = db;
        }
        public List<BookingServiceDTO> GetBookingServices(int id)
        {
            return db.BookingsServices.GetList().Select(i => new BookingServiceDTO(i)).Where(i => i.ID == id).ToList();
        }
    }
}
