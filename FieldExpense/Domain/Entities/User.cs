using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Core.Entities.BaseUser
    {

        public string IBAN { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<ExpenseRequest> ExpenseRequests { get; set; }
    }

}
