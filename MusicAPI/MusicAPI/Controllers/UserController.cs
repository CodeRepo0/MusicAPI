using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.Models;
using MusicAPI.Repos;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo) { 
            _userRepo = userRepo;
        }
        [HttpPost]
        public IActionResult PostUser(UserModel user)
        {
            int? op = _userRepo.AddUser(user);
            if (op != null) { 
                return Ok("User Added");
            }
            return BadRequest("Naah");
        }
        [HttpGet]
        public IActionResult GetUser() {
            return( Ok(_userRepo.GetUserList()));
        }
    }
}
