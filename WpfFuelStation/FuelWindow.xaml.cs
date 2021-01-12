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
    /// Логика взаимодействия для FuelWindow.xaml
    /// </summary>
    public partial class FuelWindow : MahApps.Metro.Controls.MetroWindow
    {
        [Dependency]
        public FuelView FuelView
        {
            set => DataContext = value;
        }
        public FuelWindow()
        {
            InitializeComponent();
        }
    }
}
