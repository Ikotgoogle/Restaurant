using System;
using System.Windows;
using Restaurant.Model;
using Restaurant.View.Command;
using Restaurant.ViewModel;

namespace Restaurant.View
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Table selectedTable = new Table();
        public Result(Table table)
        {
            InitializeComponent();
            selectedTable = table;
            DataContext = selectedTable;
            qwe.DataContext = new RezulsCommand();
        }

        public void makeResut(Object sender, EventArgs e)
        {
            DialogResult = true;
        }

        private double _bill;
        public double Bill
        {
            get => _bill;
            set { _bill = value; }
        }
        
    }
}
