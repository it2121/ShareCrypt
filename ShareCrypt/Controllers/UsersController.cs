using Microsoft.AspNetCore.Mvc;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;

namespace ShareCrypt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersRepo _usersRepo;

        public UsersController(IUsersRepo usersRepo) {
            _usersRepo = usersRepo;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Users>))]

        public IActionResult GetUsers() {
        
        var users = _usersRepo.GetUsers();
           
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }
            return Ok(users);
        
        }

    }
}
