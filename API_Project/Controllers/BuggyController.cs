using API_Project.Data;
using API_Project.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{

    public class BuggyController : BaseController
    {
        private readonly ApplicationDB _context;

        public BuggyController( ApplicationDB context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret text";
        }
        
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.users.Find(-1);
            if(thing == null) return NotFound();
            return thing;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.users.Find(-1);
            var thingtoreturn = thing.ToString();
            return thingtoreturn;
        }
        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequset()
        {
            return BadRequest("this was not good Request");
        }

    }
}
