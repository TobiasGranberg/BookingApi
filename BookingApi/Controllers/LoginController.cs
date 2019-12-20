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
        public ActionResult<bool> Login(LoginModel loginModel)
        {
            bool result = false;
            User user = _context.User.Where(e => e.Email == loginModel.email && e.Password == loginModel.password).FirstOrDefault();
            if (user != null)
            {
                result = true;
            }
            return result;
        }

        [Route("register")]
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