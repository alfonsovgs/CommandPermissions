using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace CommandPermissions.Identity
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;
 
        public CustomIdentity Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }
     
        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }
 
        public bool IsInRole(string role)
        {
            return _identity.Roles.Contains(role);
        }

        public List<int> Permissions() => _identity.Permissions;
    }
}
