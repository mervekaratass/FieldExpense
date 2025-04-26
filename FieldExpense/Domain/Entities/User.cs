using Core.Entities;

namespace Domain.Entities
{
    public class User : BaseUser
    {

        public string IBAN { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<ExpenseRequest> ExpenseRequests { get; set; }
    }

}
