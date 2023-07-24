using Microsoft.AspNetCore.Identity;
using QuanLyGhiDanh.Model;

namespace QuanLyGhiDanh.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
