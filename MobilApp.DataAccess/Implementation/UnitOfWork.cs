using Microsoft.AspNetCore.Mvc;
using MobilApp.API.Services;
using MobilApp.DataAccess.Context;
using MobilApp.Entities;
using MobilApp.Repository;
using System.Linq.Expressions;
using System.Security.Claims;

namespace MobilApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly MobilAppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        readonly ITokenService _tokenService;

        public AuthController(MobilAppDbContext context, IConfiguration configuration, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _configuration = configuration;
            _tokenService = tokenService;
        }
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(string Eposta, string Password)
        {
            Expression<Func<User, bool>> predicate = x => x.Eposta == Eposta && x.Password == Password;

            var user = _unitOfWork.User.Authenticate(predicate);
            if (user == null)
            {
                return Unauthorized();
            }
            if (user.IsActive == false) { return Ok(new { Status = 0, message = "Kullanıcı hesabınız pasif durumdadır." }); }

            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sid, user.NameSurname.ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.LastToken = refreshToken;
            user.TokenUseDate = DateTime.Now.AddDays(7);
            _context.SaveChanges();
            return Ok(new
            {
                Status = 1,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
