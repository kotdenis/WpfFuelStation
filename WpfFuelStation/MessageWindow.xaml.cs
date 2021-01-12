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
using System.Windows.Shapes;
using Unity;
using WpfFuelStation.ViewModels;

namespace WpfFuelStation
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : MahApps.Metro.Controls.MetroWindow
    {
        [Dependency]
        public ViewMessage ViewMessage
        {
            set => DataContext = value;
        }
        public MessageWindow()
        {
            InitializeComponent();
        }
    }
}
