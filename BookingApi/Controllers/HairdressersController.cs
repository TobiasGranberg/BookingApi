using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingApi.Models;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairdressersController : ControllerBase
    {
        private readonly BookingDBContext _context;

        public HairdressersController(BookingDBContext context)
        {
            _context = context;
        }

        // GET: api/Hairdressers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hairdresser>>> GetHairdresser()
        {
            return await _context.Hairdresser.ToListAsync();
        }

        // GET: api/Hairdressers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hairdresser>> GetHairdresser(int id)
        {
            var hairdresser = await _context.Hairdresser.FindAsync(id);

            if (hairdresser == null)
            {
                return NotFound();
            }

            return hairdresser;
        }

        // PUT: api/Hairdressers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHairdresser(int id, Hairdresser hairdresser)
        {
            if (id != hairdresser.Id)
            {
                return BadRequest();
            }

            _context.Entry(hairdresser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairdresserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hairdressers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Hairdresser>> PostHairdresser(Hairdresser hairdresser)
        {
            _context.Hairdresser.Add(hairdresser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHairdresser), new { id = hairdresser.Id }, hairdresser);
        }

        // DELETE: api/Hairdressers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hairdresser>> DeleteHairdresser(int id)
        {
            var hairdresser = await _context.Hairdresser.FindAsync(id);
            if (hairdresser == null)
            {
                return NotFound();
            }

            _context.Hairdresser.Remove(hairdresser);
            await _context.SaveChangesAsync();

            return hairdresser;
        }

        private bool HairdresserExists(int id)
        {
            return _context.Hairdresser.Any(e => e.Id == id);
        }
    }
}
