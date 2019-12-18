﻿using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class User
    {
        public User()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
