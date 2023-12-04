using DomainModel;

namespace Interfaces.DTO
{
    public class ClientDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? CountBooking { get; set; }

        public ClientDTO() { }
        public ClientDTO(Client client)
        {
            ID = client.ID;
            UserID = client.UserID;
            PhoneNumber = client.PhoneNumber;
            EmailAddress = client.EmailAddress;
            CountBooking = client.CountBooking;
        }
    }
}
