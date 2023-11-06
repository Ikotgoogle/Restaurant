﻿using Restaurant.ViewModel;
using System.Windows.Controls;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }
    }
}
