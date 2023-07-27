using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGhiDanh.Data;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocviensController : ControllerBase
    {
        private readonly QuanLyGhiDanhContext _context;

        public HocviensController(QuanLyGhiDanhContext context)
        {
            _context = context;
        }

        // GET: api/Hocviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hocvien>>> GetHocviens()
        {
            if (_context.Hocviens == null)
            {
                return NotFound();
            }
            return await _context.Hocviens.ToListAsync();
        }

        // GET: api/Hocviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hocvien>> GetHocvien(int id)
        {
            if (_context.Hocviens == null)
            {
                return NotFound();
            }
            var hocvien = await _context.Hocviens.FindAsync(id);

            if (hocvien == null)
            {
                return NotFound();
            }

            return hocvien;
        }

        // PUT: api/Hocviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocvien(int id, Hocvien hocvien)
        {
            if (id != hocvien.Idhocvien)
            {
                return BadRequest();
            }

            _context.Entry(hocvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocvienExists(id))
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

        // POST: api/Hocviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hocvien>> PostHocvien(Hocvien hocvien)
        {
            if (_context.Hocviens == null)
            {
                return Problem("Entity set 'QuanLyGhiDanhContext.Hocviens'  is null.");
            }
            _context.Hocviens.Add(hocvien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHocvien", new { id = hocvien.Idhocvien }, hocvien);
        }

        // DELETE: api/Hocviens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHocvien(int id)
        {
            if (_context.Hocviens == null)
            {
                return NotFound();
            }
            var hocvien = await _context.Hocviens.FindAsync(id);
            if (hocvien == null)
            {
                return NotFound();
            }

            _context.Hocviens.Remove(hocvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HocvienExists(int id)
        {
            return (_context.Hocviens?.Any(e => e.Idhocvien == id)).GetValueOrDefault();
        }
    }
}
