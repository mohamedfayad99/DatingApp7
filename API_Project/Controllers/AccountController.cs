using API_Project.Data;
using API_Project.Entities;
using API_Project.Models;
using API_Project.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
namespace API_Project.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ApplicationDB _context;
        private readonly ITokenService _tokenService;

        public AccountController(ApplicationDB context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if( await isExist(registerDTO.username)) return BadRequest("this username is taken ! ");
            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                UserName= registerDTO.username.ToLower(),
                PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.password)),
                PasswordSalt=hmac.Key
            };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDTO
            {
                username= user.UserName,
                token=_tokenService.CreateToken(user),
            };
        }
        [Authorize]
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user=await _context.users.SingleOrDefaultAsync(s=>s.UserName==loginDTO.username.ToLower());
            if (user == null) return Unauthorized("username not valid!");
            // second check for password
            using var hmac=new HMACSHA512(user.PasswordSalt);
            var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.password));
            for(int i = 0; i < computedhash.Length; i++)
            {
                if ( computedhash[i] != user.PasswordHash[i]) return Unauthorized("password not valid!");
            }
            return new UserDTO
            {
                username= user.UserName,
                token=_tokenService.CreateToken(user),
            };
        }

        private async Task<bool> isExist(string uasername)
        {
            return await _context.users.AnyAsync(s=> s.UserName==uasername.ToLower());
        }
    }
}
