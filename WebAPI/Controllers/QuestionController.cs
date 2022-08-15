using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("getquestionbyid")]
        public IActionResult GetQuestion()
        {
            //_questionServices.GetQuestion(5);
            return Ok(new { status= 200, message = "Okey" });

        }

        [HttpGet("getquestions")]
        public IActionResult GetQuestions()
        {
            var question = _questionServices.GetQuestions();
            return Ok(new { status = 200, message = question});
        }
    }
}
