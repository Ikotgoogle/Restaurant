using System.Windows.Controls;
using Restaurant.ViewModel;
using System.Windows;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : ContentControl
    {
        public MenuPage()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }
    }
}
