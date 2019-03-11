using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace CommandPermissions.Commands
{
    public static class SecurityCommand
    {
        private interface ISecurityMode
        {
            void Add(ICommand command, List<int> permissions);
            List<int> GetPermissions(ICommand command);
        }

        private class IntSecurityMode : ISecurityMode
        {
            private readonly Dictionary<ICommand, List<int>> _permissions;

            public IntSecurityMode()
            {
                _permissions = new Dictionary<ICommand, List<int>>();
            }

            public void Add(ICommand command, List<int> permissions)
            {
                _permissions.Remove(command);
                _permissions.Add(command, permissions);
            }

            public List<int> GetPermissions(ICommand command) => _permissions[command];
        }

        private static readonly ISecurityMode Security = new IntSecurityMode();

        public static void Add(ICommand command, List<int> value) => Security.Add(command, value);

        public static void Add(ICommand command, IList<int> value) => Add(command, value.ToList());

        public static bool HasPermissions(ICommand command, List<int> userPermissions)
        {
            var permissions = Security.GetPermissions(command);
            return userPermissions.Exists(x => permissions.Contains(x));
        }
    }
}