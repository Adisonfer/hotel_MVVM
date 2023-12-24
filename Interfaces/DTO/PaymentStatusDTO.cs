using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class PaymentStatusDTO
    {
        public int ID { get; set; }

        public string StatusName { get; set; }

        public PaymentStatusDTO(PaymentStatus payment) 
        { 
            ID = payment.ID;
            StatusName = payment.StatusName;
        }
    }
}
