using DoctorsView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.ViewModels
{
    public class LoginVM
    {
        public User User { get; set; }

        public LoginVM()
        {
            User = new User();
        }
    }
}
