﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BookingDBContext _context;

        public LoginController(BookingDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<bool> Login(string email, string password)
        {
            bool result = false;
            User user = _context.User.Where(e => e.Email == email && e.Password == password).FirstOrDefault();
            if (user != null)
            {
                result = true;
            }
            return result;
        }
    }
}