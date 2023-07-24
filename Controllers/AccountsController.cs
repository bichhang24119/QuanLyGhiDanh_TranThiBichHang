using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyGhiDanh.Model;
using QuanLyGhiDanh.Repositories;

namespace QuanLyGhiDanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountsController(IAccountRepository repo)
        {
            accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signup)
        {
            var result = await accountRepo.SignUpAsync(signup);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signin)
        {
            var result = await accountRepo.SignInAsync(signin);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
