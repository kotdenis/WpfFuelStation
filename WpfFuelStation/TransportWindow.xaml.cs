using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;
using WpfFuelStation.ViewModels;

namespace WpfFuelStation
{
    /// <summary>
    /// Логика взаимодействия для TransportWindow.xaml
    /// </summary>
    public partial class TransportWindow : MahApps.Metro.Controls.MetroWindow
    {
        [Dependency]
        public TransportView TransportView
        {
            set => DataContext = value;
        }
        public TransportWindow()
        {
            InitializeComponent();
        }
    }
}
