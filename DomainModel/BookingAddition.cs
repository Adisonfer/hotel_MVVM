namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookingService")]
    public partial class BookingAddition
    {
        public int ID { get; set; }

        public int BookingID { get; set; }

        public int AdditionID { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Addition Addition { get; set; }
    }
}
