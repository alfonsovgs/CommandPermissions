using System;
using System.Threading;
using System.Windows.Input;
using CommandPermissions.Identity;

namespace CommandPermissions.Commands
{
    public class MyCustomCommand : ICommand
    {
        private readonly Action _execute;

        public MyCustomCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            var permissions = customPrincipal?.Permissions();
            var canExecute = SecurityCommand.HasPermissions(this, permissions);
            if(canExecute) _execute?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}
