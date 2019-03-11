using System.Collections.Generic;
using System.Security.Principal;

namespace CommandPermissions.Identity
{
    public class CustomIdentity : IIdentity
    {
        public string Name { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }
        public string[] Roles { get; private set; }
        public List<int> Permissions { get; private set; }

        public CustomIdentity(string name, string[] roles)
        {
            Name = name;
            Roles = roles;
        }

        public CustomIdentity(string name, string[] roles, List<int> permissions)
        {
            Name = name;
            Roles = roles;
            Permissions = permissions;
        }
    }
}
