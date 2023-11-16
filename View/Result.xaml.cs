using System;
using System.Windows;
using System.Windows.Controls;
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
            qwe.DataContext = new ResultCommand() { ContentCtrl = new ContentControl() };

            var test = qwe.DataContext as ResultCommand;
            test.Bill = selectedTable.Bill;
            ResultCommand resultCommand = qwe.DataContext as ResultCommand;
            resultCommand.ContentCtrl = new CashPage() { DataContext = resultCommand };
        }


        public void makeResut(Object sender, EventArgs e)
        {
            DialogResult = true;
        }
    }
}
