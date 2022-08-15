using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionsDTO 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Hit { get; set; }
        public int Likes { get; set; }
        public string PhotoUrl { get; set; }
        public int Comments { get; set; }
        public string Username { get; set; }
    }
}
