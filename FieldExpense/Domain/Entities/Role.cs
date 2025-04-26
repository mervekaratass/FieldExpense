using Core.Entities;

namespace Domain.Entities
{
    public class Role : BaseRole
    {
        public virtual ICollection<User> Users { get; set; }
    }
}

