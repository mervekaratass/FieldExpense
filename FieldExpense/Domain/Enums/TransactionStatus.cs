﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum  TransactionStatus
    {

        Pending = 0,    // Bekliyor
        Approved = 1,   // Onaylandı
        Rejected = 2    // Reddedildi
    }
}
