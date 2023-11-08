using Restaurant.ViewModel;
using System.Windows.Controls;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : UserControl
    {
        public MenuPage()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }
    }
}
