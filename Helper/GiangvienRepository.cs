using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyGhiDanh.Data;
using QuanLyGhiDanh.Model;
using QuanLyGhiDanh.Repositories;

namespace QuanLyGhiDanh.Helper
{
    public class GiangvienRepository : IGiangvienRepository
    {
        private readonly QuanLyGhiDanhContext _context;
        private readonly IMapper _mapper;

        public GiangvienRepository(QuanLyGhiDanhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddGiangVienAsync(GiangvienModel giangvien)
        {
            var newgiangvien = _mapper.Map<Giangvien>(giangvien);
            _context.Giangviens!.Add(newgiangvien);
            await _context.SaveChangesAsync();

            return newgiangvien.Idgiangvien;
        }

        public async Task DeleteGiangVienAsync(int id)
        {
            var deletegiangvien = _context.Giangviens!.SingleOrDefault(b => b.Idgiangvien == id);
            if (deletegiangvien != null)
            {
                _context.Giangviens!.Remove(deletegiangvien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<GiangvienModel>> getAllGiangVienAsync()
        {
            var giangvien = await _context.Giangviens!.ToListAsync();
            return _mapper.Map<List<GiangvienModel>>(giangvien);
        }

        public async Task<GiangvienModel> getGiangVienAsync(int id)
        {
            var giangvien = await _context.Giangviens!.FindAsync(id);
            return _mapper.Map<GiangvienModel>(giangvien);
        }

        public async Task UpdateGiangVienAsync(int id, GiangvienModel giangvien)
        {
            if (id == giangvien.Idgiangvien)
            {
                var updategiangvien = _mapper.Map<Giangvien>(giangvien);
                _context.Giangviens!.Update(updategiangvien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
