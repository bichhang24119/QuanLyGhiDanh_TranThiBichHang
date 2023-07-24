using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuanLyGhiDanh.Data;
using QuanLyGhiDanh.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuanLyGhiDanh.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IConfiguration configuration;

        public AccountRepository(UserManager<User> userManager,
            SignInManager<User> signInManager, IConfiguration
            configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<string> SignInAsync(SignInModel model)
        {
            var result = await signInManager.PasswordSignInAsync
                (model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken
                (
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new User
            {
                FisrtName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
