namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public int ID { get; set; }

        public int ClientID { get; set; }

        public int BookingID { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Client Client { get; set; }
    }
}
