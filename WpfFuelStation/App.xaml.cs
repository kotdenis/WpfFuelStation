using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WpfFuelStation.Infrastructure;
using WpfFuelStation.Models;

namespace WpfFuelStation
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<IMessageSender, MessageSender>();
            container.RegisterType<IRepository, Repository>();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
