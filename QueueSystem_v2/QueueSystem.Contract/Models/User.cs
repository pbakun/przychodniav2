using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string login;
        [MaxLength(15)]
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }


        public string[] Roles { get; set; }
        public bool isActive { get; set; }
        public bool isSendingData { get; set; }
    }
}
