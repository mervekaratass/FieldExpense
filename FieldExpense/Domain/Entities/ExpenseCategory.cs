using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExpenseCategory : Entity<int>
    { 
        public string Name { get; set; }
        public virtual ICollection<ExpenseRequest> ExpenseRequests { get; set; }
    }

}
