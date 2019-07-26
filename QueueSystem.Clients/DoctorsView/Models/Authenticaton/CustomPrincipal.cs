using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Models.Authenticaton
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity customIdentity;

        public CustomIdentity Identity
        {
            get { return customIdentity ?? new AnonymousIdentity(string.Empty, string.Empty, new string[] { }); }
            set { customIdentity = value; }
        }


        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return customIdentity.Roles.Contains(role);
        }
    }
}
