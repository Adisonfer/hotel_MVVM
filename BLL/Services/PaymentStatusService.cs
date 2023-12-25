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
    public class PaymentStatusService : IPaymentStatusService
    {
        private IDbRepos db;
        public PaymentStatusService(IDbRepos db)
        {
            this.db = db;
        }

        public List<PaymentStatusDTO> GetAllPaymentStatuses()
        {
            return db.PaymentStatus.GetList().Select(i => new PaymentStatusDTO(i)).ToList();
        }

        public PaymentStatusDTO GetPaymentStatus(int id)
        {
            return new PaymentStatusDTO(db.PaymentStatus.GetItem(id));
        }
    }
}
