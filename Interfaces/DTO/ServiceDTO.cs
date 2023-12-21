using DomainModel;

namespace Interfaces.DTO
{
    public class ServiceDTO
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }

        public ServiceDTO() { }
        public ServiceDTO(Service service)
        {
            ID = service.ID;
            ServiceName = service.ServiceName;
            Price = service.Price;
        }
    }
}
