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
    public class HairdresserTreatmentsController : ControllerBase
    {
        private readonly BookingDBContext _context;

        public HairdresserTreatmentsController(BookingDBContext context)
        {
            _context = context;
        }

        // GET: api/HairdresserTreatments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HairdresserTreatment>>> GetHairdresserTreatment()
        {
            return await _context.HairdresserTreatment.ToListAsync();
        }

        // GET: api/HairdresserTreatments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HairdresserTreatment>> GetHairdresserTreatment(int id)
        {
            var hairdresserTreatment = await _context.HairdresserTreatment.FindAsync(id);

            if (hairdresserTreatment == null)
            {
                return NotFound();
            }

            return hairdresserTreatment;
        }

        // PUT: api/HairdresserTreatments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHairdresserTreatment(int id, HairdresserTreatment hairdresserTreatment)
        {
            if (id != hairdresserTreatment.Id)
            {
                return BadRequest();
            }

            _context.Entry(hairdresserTreatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairdresserTreatmentExists(id))
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

        // POST: api/HairdresserTreatments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HairdresserTreatment>> PostHairdresserTreatment(HairdresserTreatment hairdresserTreatment)
        {
            _context.HairdresserTreatment.Add(hairdresserTreatment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHairdresserTreatment), new { id = hairdresserTreatment.Id }, hairdresserTreatment);
        }

        // DELETE: api/HairdresserTreatments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HairdresserTreatment>> DeleteHairdresserTreatment(int id)
        {
            var hairdresserTreatment = await _context.HairdresserTreatment.FindAsync(id);
            if (hairdresserTreatment == null)
            {
                return NotFound();
            }

            _context.HairdresserTreatment.Remove(hairdresserTreatment);
            await _context.SaveChangesAsync();

            return hairdresserTreatment;
        }

        private bool HairdresserTreatmentExists(int id)
        {
            return _context.HairdresserTreatment.Any(e => e.Id == id);
        }
    }
}
