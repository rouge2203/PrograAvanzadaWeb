using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KidsController : ControllerBase
    {
        private readonly BoomContext _context;

        public KidsController(BoomContext context)
        {
            _context = context;
        }

        // GET: api/Kids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kids>>> GetKids()
        {
            return await _context.Kids.ToListAsync();
        }

        // GET: api/Kids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kids>> GetKids(int id)
        {
            var kids = await _context.Kids.FindAsync(id);

            if (kids == null)
            {
                return NotFound();
            }

            return kids;
        }

        // PUT: api/Kids/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKids(int id, Kids kids)
        {
            if (id != kids.Id)
            {
                return BadRequest();
            }

            _context.Entry(kids).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KidsExists(id))
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

        // POST: api/Kids
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kids>> PostKids(Kids kids)
        {
            _context.Kids.Add(kids);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKids", new { id = kids.Id }, kids);
        }

        // DELETE: api/Kids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kids>> DeleteKids(int id)
        {
            var kids = await _context.Kids.FindAsync(id);
            if (kids == null)
            {
                return NotFound();
            }

            _context.Kids.Remove(kids);
            await _context.SaveChangesAsync();

            return kids;
        }

        private bool KidsExists(int id)
        {
            return _context.Kids.Any(e => e.Id == id);
        }
    }
}
