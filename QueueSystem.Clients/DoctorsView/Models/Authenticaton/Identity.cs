using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models.Authenticaton
{
    public class CustomIdentity : IIdentity
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string[] Roles { get; private set; }

        public CustomIdentity(string name, string email, string[] roles)
        {
            Name = name;
            Email = email;
            Roles = roles;
        }

        public string AuthenticationType
        {
            get { return "Custom authentication"; }
        }

        public bool IsAuthenticated
        {
            get
            {
                return !string.IsNullOrEmpty(Name);
            }
        }
    }

    public class AnonymousIdentity : CustomIdentity
    {
        private const string EmptyString = "";

        public AnonymousIdentity(string name, string email, string[] roles) 
            : base(string.Empty, string.Empty, new string[] { })
        {

        }
    }
}
