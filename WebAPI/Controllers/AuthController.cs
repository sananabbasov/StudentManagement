using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

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

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
               var user = _userServices.Login(loginDTO);
                return Ok(new {status= 200, message= user });
            }
            catch (Exception)
            {
                return BadRequest("Login zamani xeta bas verdi. Yeniden cehd edin.");
            }
        }


        [Authorize]
        [HttpGet("getallusers")]
        public IActionResult GetUsers()
        {
            var users = _userServices.GetAllUser();
            return Ok(new { status = 200, message = users });
        }
    }
}
