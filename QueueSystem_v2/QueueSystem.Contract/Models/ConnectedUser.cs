using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueSystem.Contract.Models
{
    class ConnectedUser
    {
        public int Id { get; set; }

        public IQueueMessageCallback RegisteredUser { get; set; }

        public ConnectedUser(int id, IQueueMessageCallback registeredUser)
        {
            Id = id;
            RegisteredUser = registeredUser;
        }
    }
}
