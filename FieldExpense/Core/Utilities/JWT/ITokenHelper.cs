﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(BaseUser user, List<BaseRole> roles);
    }
}
