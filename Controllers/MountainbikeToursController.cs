using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteWebApi;
using SQLiteWebApi.Entities;

namespace SQLiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MountainbikeToursController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MountainbikeToursController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MountainbikeTours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MountainbikeTour>>> GetMountainbikeTours()
        {
            return await _context.MountainbikeTours.ToListAsync();
        }

        // GET: api/MountainbikeTours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MountainbikeTour>> GetMountainbikeTour(int id)
        {
            var mountainbikeTour = await _context.MountainbikeTours.FindAsync(id);

            if (mountainbikeTour == null)
            {
                return NotFound();
            }

            return mountainbikeTour;
        }

        // PUT: api/MountainbikeTours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMountainbikeTour(int id, MountainbikeTour mountainbikeTour)
        {
            if (id != mountainbikeTour.TourId)
            {
                return BadRequest();
            }

            _context.Entry(mountainbikeTour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MountainbikeTourExists(id))
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

        // POST: api/MountainbikeTours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MountainbikeTour>> PostMountainbikeTour(MountainbikeTour mountainbikeTour)
        {
            _context.MountainbikeTours.Add(mountainbikeTour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMountainbikeTour", new { id = mountainbikeTour.TourId }, mountainbikeTour);
        }

        // DELETE: api/MountainbikeTours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMountainbikeTour(int id)
        {
            var mountainbikeTour = await _context.MountainbikeTours.FindAsync(id);
            if (mountainbikeTour == null)
            {
                return NotFound();
            }

            _context.MountainbikeTours.Remove(mountainbikeTour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MountainbikeTourExists(int id)
        {
            return _context.MountainbikeTours.Any(e => e.TourId == id);
        }
    }
}
