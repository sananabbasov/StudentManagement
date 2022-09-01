using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionServices : IQuestionServices
    {
        private readonly IQuestionDal _questionDal;
        private readonly IUserServices _userServices;

        public QuestionServices(IQuestionDal questionDal, IUserServices userServices)
        {
            _questionDal = questionDal;
            _userServices = userServices;
        }

        public void AddQuestion(AddQuestionDTO addQuestion, string email)
        {

            var user = _userServices.GetUserByEmail(email);
            Question newQuestion = new()
            {
                Description = addQuestion.Description,
                PhotoUrl = addQuestion.PhotoUrl,
                Title = addQuestion.Title,
                UserId = user.Id,
            };
            _questionDal.Add(newQuestion);
        }
        public Question GetQuestion(int id)
        {
            return _questionDal.Get(x=>x.Id == id);
        }

        public QuestionDetailDTO GetQuestionDetail(int id)
        {
            return _questionDal.GetQuestionDetail(id);
        }

        public List<QuestionsDTO> GetQuestions()
        {
            
            return _questionDal.GetAllQuestions();
        }
    }
}
