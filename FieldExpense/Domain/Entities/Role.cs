using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseRole
    {
        public virtual ICollection<User> Users { get; set; }
    }
}

