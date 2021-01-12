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

namespace WpfFuelStation.Controls
{
    /// <summary>
    /// Логика взаимодействия для SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : MahApps.Metro.Controls.MetroWindow
    {
        [Dependency]
        public FuelCheckView FuelCheckView
        {
            set => DataContext = value;
        }
        public SettingWindow()
        {
            InitializeComponent();
        }
    }
}
