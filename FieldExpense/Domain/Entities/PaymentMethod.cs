using Core.Persistence;


namespace Domain.Entities
{
    public class PaymentMethod : Entity<int>
    {

        public string Name { get; set; }
        public ICollection<ExpenseRequest> ExpenseRequests { get; set; }
    }

}
