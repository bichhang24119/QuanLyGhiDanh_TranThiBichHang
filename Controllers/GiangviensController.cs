using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyGhiDanh.Data;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangviensController : ControllerBase
    {
        private readonly QuanLyGhiDanhContext _context;

        public GiangviensController(QuanLyGhiDanhContext context)
        {
            _context = context;
        }

        // GET: api/Giangviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giangvien>>> GetGiangviens()
        {
            if (_context.Giangviens == null)
            {
                return NotFound();
            }
            return await _context.Giangviens.ToListAsync();
        }

        // GET: api/Giangviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giangvien>> GetGiangvien(int id)
        {
            if (_context.Giangviens == null)
            {
                return NotFound();
            }
            var giangvien = await _context.Giangviens.FindAsync(id);

            if (giangvien == null)
            {
                return NotFound();
            }

            return giangvien;
        }

        // PUT: api/Giangviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutGiangvien(int id, Giangvien giangvien)
        {
            if (id != giangvien.Idgiangvien)
            {
                return BadRequest();
            }

            _context.Entry(giangvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangvienExists(id))
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

        // POST: api/Giangviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Giangvien>> PostGiangvien(Giangvien giangvien)
        {
            if (_context.Giangviens == null)
            {
                return Problem("Entity set 'QuanLyGhiDanhContext.Giangviens'  is null.");
            }
            _context.Giangviens.Add(giangvien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGiangvien", new { id = giangvien.Idgiangvien }, giangvien);
        }

        // DELETE: api/Giangviens/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteGiangvien(int id)
        {
            if (_context.Giangviens == null)
            {
                return NotFound();
            }
            var giangvien = await _context.Giangviens.FindAsync(id);
            if (giangvien == null)
            {
                return NotFound();
            }

            _context.Giangviens.Remove(giangvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiangvienExists(int id)
        {
            return (_context.Giangviens?.Any(e => e.Idgiangvien == id)).GetValueOrDefault();
        }
    }
}
