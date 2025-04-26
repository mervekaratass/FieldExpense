

using Core.Persistence;

namespace Core.Entities
{
    public class BaseUser : Entity<int>
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
