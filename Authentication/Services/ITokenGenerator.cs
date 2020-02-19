﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Service
{
    public interface ITokenGenerator
    {
        string GetJWTToken(string userId);
    }
}