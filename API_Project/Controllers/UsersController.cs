using API_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly ApplicationDB _context;

        public UsersController(ApplicationDB context) {
           _context = context;
        }
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
