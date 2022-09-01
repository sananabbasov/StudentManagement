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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionServices _questionServices;

        public QuestionController(IQuestionServices questionServices)
        {
            _questionServices = questionServices;
        }

        [HttpGet("getquestionbyid/{id}")]
        public IActionResult GetQuestion(int id)
        {
            var question = _questionServices.GetQuestionDetail(id);
            return Ok(new { status= 200, message = question });

        }

        [Authorize]
        [HttpPost("addquestion")]
        public IActionResult AddQuestion(AddQuestionDTO addQuestion)
        {
            var userToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityToken(userToken);
            var email = handler.Claims.FirstOrDefault(x=>x.Type == "email").Value;

            _questionServices.AddQuestion(addQuestion, email);
            
            return Ok("Sual elave olundu");
        }

        [HttpGet("getquestions")]
        public IActionResult GetQuestions()
        {
            var question = _questionServices.GetQuestions();
            return Ok(new { status = 200, message = question});
        }
    }
}
