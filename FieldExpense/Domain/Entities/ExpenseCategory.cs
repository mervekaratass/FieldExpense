using Core.Persistence;

namespace Domain.Entities
{
    public class ExpenseCategory : Entity<int>
    { 
        public string Name { get; set; }
        public virtual ICollection<ExpenseRequest> ExpenseRequests { get; set; }
    }

}
