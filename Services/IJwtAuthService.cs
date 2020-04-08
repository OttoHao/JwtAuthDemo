﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Services
{
    public interface IJwtAuthService
    {
        string Authenticate(string username, string password);
    }
}
