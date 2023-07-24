using AutoMapper;
using QuanLyGhiDanh.Data;
using QuanLyGhiDanh.Model;
using QuanLyGhiDanh.Repositories;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGhiDanh.Helper
{
    public class HocvienRepository : IHocvienRepository
    {
        private readonly QuanLyGhiDanhContext _context;
        private readonly IMapper _mapper;

        public HocvienRepository(QuanLyGhiDanhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddHocVienAsync(HocvienModel hocvien)
        {
            var newhocvien = _mapper.Map<Hocvien>(hocvien);
            _context.Hocviens!.Add(newhocvien);
            await _context.SaveChangesAsync();

            return newhocvien.Idhocvien;
        }

        public async Task DeleteHocVienAsync(int id)
        {
            var deletehocvien = _context.Hocviens!.SingleOrDefault(b => b.Idhocvien == id);
            if (deletehocvien != null)
            {
                _context.Hocviens!.Remove(deletehocvien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HocvienModel>> getAllHocVienAsync()
        {
            var hocvien = await _context.Hocviens!.ToListAsync();
            return _mapper.Map<List<HocvienModel>>(hocvien);
        }

        public async Task<HocvienModel> getHocVienAsync(int id)
        {
            var hocvien = await _context.Hocviens!.FindAsync(id);
            return _mapper.Map<HocvienModel>(hocvien);
        }

        public async Task UpdateHocVienAsync(int id, HocvienModel hocvien)
        {
            if (id == hocvien.Idhocvien)
            {
                var updatehocvien = _mapper.Map<Hocvien>(hocvien);
                _context.Hocviens!.Update(updatehocvien);
                await _context.SaveChangesAsync();
            }
        }
    }
}
