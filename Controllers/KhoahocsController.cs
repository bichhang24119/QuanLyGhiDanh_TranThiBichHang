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
    public class KhoahocsController : ControllerBase
    {
        private readonly QuanLyGhiDanhContext _context;

        public KhoahocsController(QuanLyGhiDanhContext context)
        {
            _context = context;
        }

        // GET: api/Khoahocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoahoc>>> GetKhoahoc()
        {
          if (_context.Khoahoc == null)
          {
              return NotFound();
          }
            return await _context.Khoahoc.ToListAsync();
        }

        // GET: api/Khoahocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khoahoc>> GetKhoahoc(int id)
        {
          if (_context.Khoahoc == null)
          {
              return NotFound();
          }
            var khoahoc = await _context.Khoahoc.FindAsync(id);

            if (khoahoc == null)
            {
                return NotFound();
            }

            return khoahoc;
        }

        // PUT: api/Khoahocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutKhoahoc(int id, Khoahoc khoahoc)
        {
            if (id != khoahoc.Idkhoahoc)
            {
                return BadRequest();
            }

            _context.Entry(khoahoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoahocExists(id))
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

        // POST: api/Khoahocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Khoahoc>> PostKhoahoc(Khoahoc khoahoc)
        {
          if (_context.Khoahoc == null)
          {
              return Problem("Entity set 'QuanLyGhiDanhContext.Khoahoc'  is null.");
          }
            _context.Khoahoc.Add(khoahoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoahoc", new { id = khoahoc.Idkhoahoc }, khoahoc);
        }

        // DELETE: api/Khoahocs/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteKhoahoc(int id)
        {
            if (_context.Khoahoc == null)
            {
                return NotFound();
            }
            var khoahoc = await _context.Khoahoc.FindAsync(id);
            if (khoahoc == null)
            {
                return NotFound();
            }

            _context.Khoahoc.Remove(khoahoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoahocExists(int id)
        {
            return (_context.Khoahoc?.Any(e => e.Idkhoahoc == id)).GetValueOrDefault();
        }
    }
}
