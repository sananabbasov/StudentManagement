using Business.Abstract;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserServices : IUserServices
    {
        private readonly IUserDal _userDal;

        public UserServices(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAllUser()
        {
            return _userDal.GetAll();
        }

        public User GetUserByEmail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }

        public UserDTO Login(LoginDTO user)
        {
            var findUser = _userDal.Get(x => x.Email == user.Email);
            bool check = HashingHelper.CheckPassword(user.Password,findUser.PasswordHash,findUser.PasswordSalt);
            UserDTO userDTO = new();
            if (check)
            {
                userDTO.Id = findUser.Id;
                userDTO.Email = findUser.Email;
                userDTO.Token = TokenGenerator.Token(findUser,"Admin");
                return userDTO;
            }
            return userDTO;
        }

        public void Register(RegisterDTO user)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreateHashing(user.Password, out passwordHash, out passwordSalt);
            User newUser = new()
            {
                Email = user.Email,
                Gender = user.Gender,
                RegisterDate = DateTime.Now,
                Name = user.Name,
                Surname = user.Surname,
                ConfirmEmail = false,
                LoginAttempt = 0,
                UserActive = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userDal.Add(newUser);
        }
    }
}
