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
    public class MonhocsController : ControllerBase
    {
        private readonly QuanLyGhiDanhContext _context;

        public MonhocsController(QuanLyGhiDanhContext context)
        {
            _context = context;
        }

        // GET: api/Monhocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monhoc>>> GetMonhoc()
        {
          if (_context.Monhoc == null)
          {
              return NotFound();
          }
            return await _context.Monhoc.ToListAsync();
        }

        // GET: api/Monhocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monhoc>> GetMonhoc(int id)
        {
          if (_context.Monhoc == null)
          {
              return NotFound();
          }
            var monhoc = await _context.Monhoc.FindAsync(id);

            if (monhoc == null)
            {
                return NotFound();
            }

            return monhoc;
        }

        // PUT: api/Monhocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutMonhoc(int id, Monhoc monhoc)
        {
            if (id != monhoc.Idmonhoc)
            {
                return BadRequest();
            }

            _context.Entry(monhoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonhocExists(id))
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

        // POST: api/Monhocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Monhoc>> PostMonhoc(Monhoc monhoc)
        {
          if (_context.Monhoc == null)
          {
              return Problem("Entity set 'QuanLyGhiDanhContext.Monhoc'  is null.");
          }
            _context.Monhoc.Add(monhoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonhoc", new { id = monhoc.Idmonhoc }, monhoc);
        }

        // DELETE: api/Monhocs/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMonhoc(int id)
        {
            if (_context.Monhoc == null)
            {
                return NotFound();
            }
            var monhoc = await _context.Monhoc.FindAsync(id);
            if (monhoc == null)
            {
                return NotFound();
            }

            _context.Monhoc.Remove(monhoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonhocExists(int id)
        {
            return (_context.Monhoc?.Any(e => e.Idmonhoc == id)).GetValueOrDefault();
        }
    }
}
