using QuanLyGhiDanh.Model;

namespace QuanLyGhiDanh.Repositories
{
    public interface IHocvienRepository
    {
        public Task<List<HocvienModel>> getAllHocVienAsync();
        public Task<HocvienModel> getHocVienAsync(int id);
        public Task<int> AddHocVienAsync(HocvienModel hocvien);
        public Task UpdateHocVienAsync(int id, HocvienModel hocvien);
        public Task DeleteHocVienAsync(int id);
    }
}
