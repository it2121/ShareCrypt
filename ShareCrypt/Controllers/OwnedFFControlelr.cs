using Microsoft.AspNetCore.Mvc;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;
using ShareCrypt.Repository;
using Microsoft.AspNetCore.Mvc;
using ShareCrypt.Interfaces;
using ShareCrypt.Models;


[Route("api/[controller]")]
    [ApiController]
    public class OwnedFFControlelr : Controller
{

        private readonly IOwnedFfRepo _OwnedFF;

        public OwnedFFControlelr(IOwnedFfRepo OwnedFfRepo)
        {
            _OwnedFF = OwnedFfRepo;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OwnedFF>))]

        public IActionResult GetOwnedFF()
        {

            var ownedFF = _OwnedFF.GetOwnedFF();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }
            return Ok(ownedFF);

        }


    
}
