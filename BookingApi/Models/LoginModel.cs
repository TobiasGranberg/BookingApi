﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Models
{
    public class LoginModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}