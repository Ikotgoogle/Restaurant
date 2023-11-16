    using Restaurant.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;

    namespace Restaurant.View.Command
    {
        public class ResultCommand : PropertyChangedClass
        {
            private ContentControl contentCtrl;
            public ContentControl ContentCtrl{
                get{
                    return contentCtrl;
                }
                set { contentCtrl = value; OnPropertyChanged(nameof(ContentCtrl)); }
            }

            private RelayCommand setUpPage;
            public RelayCommand SetUpPage{
                get{
                    return setUpPage ?? (setUpPage = new RelayCommand(obj =>
                    {
                        if ((obj as string) == "NonCash") ContentCtrl = new NonCashPage() { };
                        if ((obj as string) == "Cash") ContentCtrl = new CashPage();
                    }));
                }
            }

        private double _bill;
        public double Bill{
            get => _bill;
            set { _bill = value; OnPropertyChanged(nameof(Bill)); }
        }
    }
}
