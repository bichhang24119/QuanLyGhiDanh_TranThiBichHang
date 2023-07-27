using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGhiDanh.Data;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobomonsController : ControllerBase
    {
        private readonly QuanLyGhiDanhContext _context;

        public TobomonsController(QuanLyGhiDanhContext context)
        {
            _context = context;
        }

        // GET: api/Tobomons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tobomon>>> GetTobomon()
        {
          if (_context.Tobomon == null)
          {
              return NotFound();
          }
            return await _context.Tobomon.ToListAsync();
        }

        // GET: api/Tobomons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tobomon>> GetTobomon(int id)
        {
          if (_context.Tobomon == null)
          {
              return NotFound();
          }
            var tobomon = await _context.Tobomon.FindAsync(id);

            if (tobomon == null)
            {
                return NotFound();
            }

            return tobomon;
        }

        // PUT: api/Tobomons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTobomon(int id, Tobomon tobomon)
        {
            if (id != tobomon.Idtobomon)
            {
                return BadRequest();
            }

            _context.Entry(tobomon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TobomonExists(id))
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

        // POST: api/Tobomons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tobomon>> PostTobomon(Tobomon tobomon)
        {
          if (_context.Tobomon == null)
          {
              return Problem("Entity set 'QuanLyGhiDanhContext.Tobomon'  is null.");
          }
            _context.Tobomon.Add(tobomon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTobomon", new { id = tobomon.Idtobomon }, tobomon);
        }

        // DELETE: api/Tobomons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTobomon(int id)
        {
            if (_context.Tobomon == null)
            {
                return NotFound();
            }
            var tobomon = await _context.Tobomon.FindAsync(id);
            if (tobomon == null)
            {
                return NotFound();
            }

            _context.Tobomon.Remove(tobomon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TobomonExists(int id)
        {
            return (_context.Tobomon?.Any(e => e.Idtobomon == id)).GetValueOrDefault();
        }
    }
}
