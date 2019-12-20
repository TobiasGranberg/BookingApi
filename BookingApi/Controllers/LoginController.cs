using System;
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

        [HttpPost]
        public ActionResult<User>Login(string email, string password)
        {
            //User usr = new User();
            //usr.Fname = "david";
            //usr.Lname = "hoppsan";
            //usr.Id = 3;
            //usr.Password = "password";
            //usr.Email = "email";

            //var user = _context.User.FirstOrDefault(m => m.Email == email);
            //if (user != null)
            //{
            //    if (user.Password == password) return user;
            //}

            User user = _context.User.Where(m => m.Email == email).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine("TEST: " + email);

            return user;
        }

        [Route("login/register")]
        [HttpPost]
        public bool Register(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}