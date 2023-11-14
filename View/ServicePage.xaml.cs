using Restaurant.Model;
using Restaurant.ViewModel;
using System.Buffers;
using System.Windows.Controls;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : ContentControl
    {
        public ServicePage()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }

        private void Result_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Result result = new Result();

            result.Show();
        }
    }
}
