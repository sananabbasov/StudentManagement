using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionServices
    {
        void AddQuestion(AddQuestionDTO addQuestion, string email);
        QuestionDetailDTO GetQuestionDetail(int id);
        Question GetQuestion(int id);
        List<QuestionsDTO> GetQuestions();
    }
}
