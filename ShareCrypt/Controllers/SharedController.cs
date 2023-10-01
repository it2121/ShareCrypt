using Microsoft.AspNetCore.Mvc;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;
using ShareCrypt.Repository;

namespace ShareCrypt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : Controller
    {

        private readonly ISharedRepo     _sharedRepo;

        public SharedController(ISharedRepo sharedRepo)
        {
            _sharedRepo = sharedRepo;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Shared>))]

        public IActionResult GetShared()
        {

            var shared = _sharedRepo.GetShared();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }
            return Ok(shared);

        }

    }
}
