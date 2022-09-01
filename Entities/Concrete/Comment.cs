using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }
        public string Message { get; set; }
    }
}
