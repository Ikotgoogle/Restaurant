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
            main.DataContext = new ResultCommand() { ContentCtrl = new ContentControl() };

            var bill = main.DataContext as ResultCommand;
            bill.Bill = selectedTable.Bill;
            var num = main.DataContext as ResultCommand;
            num.TableNum = selectedTable.Id;
            ResultCommand resultCommand = main.DataContext as ResultCommand;
            resultCommand.ContentCtrl = new CashPage() { DataContext = resultCommand };
        }


        public void makeResut(Object sender, EventArgs e)
        {
            DialogResult = true;
        }
    }
}
