using System.Windows;
using Restaurant.Model;
using Restaurant.ViewModel;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {

        public Result()
        {
            InitializeComponent();
            DataContext = new AppVM();
        }



    }
}
