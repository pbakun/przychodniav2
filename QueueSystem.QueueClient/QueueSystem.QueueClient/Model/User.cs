using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.QueueClient.Model
{
    public class User
    {
        // id > 100 for receiving only users
        public int Id { get; set; }
        
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool isActive { get; set; }

        public bool isSendingData { get; set; }

    }
}
