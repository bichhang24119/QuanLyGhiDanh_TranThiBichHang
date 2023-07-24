using AutoMapper;
using QuanLyGhiDanh.Data;
using QuanLyGhiDanh.Model;

namespace QuanLyGhiDanh.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Hocvien, HocvienModel>();
            CreateMap<Giangvien, GiangvienModel>();
        }
    }
}
