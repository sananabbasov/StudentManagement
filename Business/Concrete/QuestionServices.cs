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

        public Question GetQuestion(int id)
        {
            return _questionDal.Get(x=>x.Id == id);
        }

        public List<QuestionsDTO> GetQuestions()
        {
            List<QuestionsDTO> result = new()
            {
                new QuestionsDTO()
                {
                    Id = 1,
                    Title = "Lorem Ipsum is simply dummy text",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Hit = 0,
                    Likes = 0,
                    PhotoUrl = "https://cdn.pixabay.com/photo/2016/03/27/18/54/technology-1283624_960_720.jpg",
                    Comments = 0,
                    Username = "Lorem Ipsum"
                },
                new QuestionsDTO()
                {
                    Id = 2,
                    Title = "Lorem Ipsum is simply dummy text",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Hit = 0,
                    Likes = 0,
                    PhotoUrl = "https://cdn.pixabay.com/photo/2016/03/27/18/54/technology-1283624_960_720.jpg",
                    Comments = 0,
                    Username = "Lorem Ipsum"
                },
                new QuestionsDTO()
                {
                    Id = 3,
                    Title = "Lorem Ipsum is simply dummy text",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Hit = 0,
                    Likes = 0,
                    PhotoUrl = "https://cdn.pixabay.com/photo/2016/03/27/18/54/technology-1283624_960_720.jpg",
                    Comments = 0,
                    Username = "Lorem Ipsum"
                },
                new QuestionsDTO()
                {
                    Id = 4,
                    Title = "Lorem Ipsum is simply dummy text",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                    Hit = 0,
                    Likes = 0,
                    PhotoUrl = "https://cdn.pixabay.com/photo/2016/03/27/18/54/technology-1283624_960_720.jpg",
                    Comments = 0,
                    Username = "Lorem Ipsum"
                },
            };
            return result;
        }
    }
}
