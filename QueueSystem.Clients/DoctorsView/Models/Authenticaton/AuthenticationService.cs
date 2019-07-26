using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models.Authenticaton
{
    public class AuthenticationService : IAuthenticationService
    {
        private class InternalUserData
        {
            public string Username { get; private set; }
            public string Email { get; private set; }
            public string HashedPassword { get; private set; }
            public string[] Roles { get; private set; }

            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }
        }

        public User AuthenticateUser(string username, string password)
        {
            //TODO

            return new User();
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            //Convert slated password to byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);

            //Use has algorith to calculate hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }
    }
}
