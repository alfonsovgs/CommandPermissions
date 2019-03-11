using System.Collections.Generic;
using System.Threading;
using System.Windows;
using CommandPermissions.Identity;

namespace CommandPermissions
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CustomPrincipal customPrincipal = new CustomPrincipal();
            customPrincipal.Identity = new CustomIdentity("", new []{""}, new List<int> {1,2,3});
            Thread.CurrentPrincipal = customPrincipal;
        }
    }
}
