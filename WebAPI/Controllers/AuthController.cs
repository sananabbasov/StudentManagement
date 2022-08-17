using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO user)
        {
            try
            {
                _userServices.Register(user);
                return Ok(new { status = 200, message = "Ugurla qeydiyyatdan kecdiniz. Hesabi tesdiqlemek ucun emailinize baxin." });
            }
            catch (Exception e)
            {
                return BadRequest("Qeydiyyat zamani xeta bas verdi. Yeniden cehd edin.");
            }
        }
    }
}
