using Microsoft.AspNetCore.Mvc;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;

namespace ShareCrypt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ffcontroller : Controller 
    {

        private readonly IFfRepo _ffRepo;

        public Ffcontroller(IFfRepo ffRepo)
        {
            _ffRepo = ffRepo;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FF>))]

        public IActionResult GetFF()
        {

            var ff = _ffRepo.GetFF();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }
            return Ok(ff);

        }



    }
}
