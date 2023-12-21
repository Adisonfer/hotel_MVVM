using DomainModel;

namespace Interfaces.DTO
{
    public class AdditionDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public AdditionDTO() { }
        public AdditionDTO(Addition service)
        {
            ID = service.ID;
            Name = service.Name;
            Price = service.Price;
        }
    }
}
