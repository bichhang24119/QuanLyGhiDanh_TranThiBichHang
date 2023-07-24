using QuanLyGhiDanh.Model;

namespace QuanLyGhiDanh.Repositories
{
    public interface IGiangvienRepository
    {
        public Task<List<GiangvienModel>> getAllGiangVienAsync();
        public Task<GiangvienModel> getGiangVienAsync(int id);
        public Task<int> AddGiangVienAsync(GiangvienModel giangvien);
        public Task UpdateGiangVienAsync(int id, GiangvienModel giangvien);
        public Task DeleteGiangVienAsync(int id);
    }
}
