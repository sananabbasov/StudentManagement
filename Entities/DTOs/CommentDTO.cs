using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
