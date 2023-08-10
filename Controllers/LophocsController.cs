using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGhiDanh.Data;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LophocsController : ControllerBase
    {
        private readonly QuanLyGhiDanhContext _context;

        public LophocsController(QuanLyGhiDanhContext context)
        {
            _context = context;
        }

        // GET: api/Lophocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lophoc>>> GetLophoc()
        {
          if (_context.Lophoc == null)
          {
              return NotFound();
          }
            return await _context.Lophoc.ToListAsync();
        }

        // GET: api/Lophocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lophoc>> GetLophoc(int id)
        {
          if (_context.Lophoc == null)
          {
              return NotFound();
          }
            var lophoc = await _context.Lophoc.FindAsync(id);

            if (lophoc == null)
            {
                return NotFound();
            }

            return lophoc;
        }

        // PUT: api/Lophocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutLophoc(int id, Lophoc lophoc)
        {
            if (id != lophoc.Idlophoc)
            {
                return BadRequest();
            }

            _context.Entry(lophoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LophocExists(id))
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

        // POST: api/Lophocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Lophoc>> PostLophoc(Lophoc lophoc)
        {
          if (_context.Lophoc == null)
          {
              return Problem("Entity set 'QuanLyGhiDanhContext.Lophoc'  is null.");
          }
            _context.Lophoc.Add(lophoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLophoc", new { id = lophoc.Idlophoc }, lophoc);
        }

        // DELETE: api/Lophocs/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLophoc(int id)
        {
            if (_context.Lophoc == null)
            {
                return NotFound();
            }
            var lophoc = await _context.Lophoc.FindAsync(id);
            if (lophoc == null)
            {
                return NotFound();
            }

            _context.Lophoc.Remove(lophoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LophocExists(int id)
        {
            return (_context.Lophoc?.Any(e => e.Idlophoc == id)).GetValueOrDefault();
        }
    }
}
