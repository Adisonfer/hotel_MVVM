namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            Review = new HashSet<Review>();
        }

        public int ID { get; set; }

        public int ClientID { get; set; }

        public int RoomID { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        public int? PaymentStatusID { get; set; }

        public int? ServiceID { get; set; }

        public int? AdministratorID { get; set; }

        public virtual Administrator Administrator { get; set; }

        public virtual Client Client { get; set; }

        public virtual Room Room { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }

        public virtual Service Service { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Review { get; set; }
    }
}
