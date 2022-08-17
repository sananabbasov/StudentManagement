﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class QuestionDal : EfRepositoryBase<Question, AppDbContext>, IQuestionDal
    {
        public List<QuestionsDTO> GetAllQuestions()
        {
            using var _context = new AppDbContext();
            var questions = _context.Questions.Include(x=>x.User).ToList();
            List<QuestionsDTO> questionsDTOList = new();
            for (int i = 0; i < questions.Count; i++)
            {
                QuestionsDTO questionsDTO = new()
                {
                    Description = questions[i].Description,
                    Comments = 0,
                    Likes = 0,
                    Hit = 0,
                    PhotoUrl = questions[i].PhotoUrl,
                    Id = questions[i].Id,
                    Title = questions[i].Title,
                    Username = questions[i].User.Name,
                };
                questionsDTOList.Add(questionsDTO);
            }


            return questionsDTOList;

        }
    }
}
