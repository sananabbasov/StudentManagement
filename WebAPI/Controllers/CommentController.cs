using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServices _commentServices;

        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        [Authorize]
        [HttpPost("addcomment")]
        public IActionResult AddComment(CommentDTO comment)
        {
            var userToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityToken(userToken);
            var email = handler.Claims.FirstOrDefault(x => x.Type == "email").Value;
            _commentServices.AddComment(comment.Message, email, comment.Id);
            return Ok(new { status = 200, message = "Comment elave olundu" });
        }

    }
}
