using DomainModel;

namespace Interfaces.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserDTO() { }
        public UserDTO (User user)
        {
            ID = user.ID;
            Login = user.Login;
            Password = user.Password;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
