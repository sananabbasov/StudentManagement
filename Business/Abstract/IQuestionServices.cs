﻿using Entities.Concrete;
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
        void AddQuestion(AddQuestionDTO addQuestion);
        Question GetQuestion(int id);
        List<QuestionsDTO> GetQuestions();
    }
}
