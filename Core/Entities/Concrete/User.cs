using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool ConfirmEmail { get; set; }
        public DateTime RegisterDate { get; set; }
        public int LoginAttempt { get; set; }
        public bool UserActive { get; set; }
        public bool Gender { get; set; }
    }
}
