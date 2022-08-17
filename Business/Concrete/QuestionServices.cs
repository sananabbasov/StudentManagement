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

        public QuestionServices(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void AddQuestion(AddQuestionDTO addQuestion)
        {
            Question newQuestion = new()
            {
                Description = addQuestion.Description,
                PhotoUrl = addQuestion.PhotoUrl,
                Title = addQuestion.Title,
                UserId = addQuestion.UserId
            };
            _questionDal.Add(newQuestion);
        }
        public Question GetQuestion(int id)
        {
            return _questionDal.Get(x=>x.Id == id);
        }

        public List<QuestionsDTO> GetQuestions()
        {
            
            return _questionDal.GetAllQuestions();
        }
    }
}
