using DomainModel;

namespace Interfaces.DTO
{
    public class AdminDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public AdminDTO() { }
        public AdminDTO(Administrator ad) {
            ID = ad.ID;
            UserID = ad.UserID;
        }
    }
}
