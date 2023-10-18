using API_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly ApplicationDB _context;

        public UsersController(ApplicationDB context) {
           _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {   
            var users=await _context.users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user =await _context.users.FindAsync(id);
            return Ok(user);
        }
    }
}
