using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models.Authenticaton
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);

        bool RegisterUser(User newUser);
    }
}
