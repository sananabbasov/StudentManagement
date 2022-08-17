using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreateHashing(string password, out byte[] passowrdHash, out byte[] passwordSalt)
        {
            using var hash = new HMACSHA512();
            passwordSalt = hash.Key;
            passowrdHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
