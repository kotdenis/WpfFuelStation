﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;
using WpfFuelStation.ViewModels;

namespace WpfFuelStation.Controls
{
    /// <summary>
    /// Логика взаимодействия для FuelGettingUserControl.xaml
    /// </summary>
    public partial class FuelGettingUserControl : MahApps.Metro.Controls.MetroContentControl
    {
        [Dependency]
        public ViewMain ViewMain
        {
            set => DataContext = value;
        }
        public FuelGettingUserControl()
        {
            InitializeComponent();
        }
    }
}
