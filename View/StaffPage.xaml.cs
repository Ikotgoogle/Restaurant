using Restaurant.ViewModel;
using System.Windows.Controls;
namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : ContentControl
    {
        public StaffPage()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }
    }
}
