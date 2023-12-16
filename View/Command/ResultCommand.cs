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
                return setUpPage ?? (setUpPage = new RelayCommand(obj => {
                    if ((obj as string) == "NonCash"){
                        ContentCtrl = new NonCashPage() { };
                    }
                    if ((obj as string) == "Cash") ContentCtrl = new CashPage();
                }));
            }
        }

        private int _bill;
        public int Bill{
            get => _bill;
            set { _bill = value; OnPropertyChanged(nameof(Bill)); }
        }

        private int _tableNum;
        public int TableNum{
            get => _tableNum;
            set { _tableNum = value; OnPropertyChanged(nameof(TableNum)); }
        }

        private double _discount;
        public double Discount{
            get => _discount;
            set { _discount = value; OnPropertyChanged(nameof(Discount)); OnPropertyChanged(nameof(Total)); }
        }

        private double _sumReceived;
        public double SumReceived{
            get => _sumReceived;
            set { _sumReceived = value; OnPropertyChanged(nameof(SumReceived)); OnPropertyChanged(nameof(Change)); }
        }

        public double Total => _bill - (_discount / 100 * _bill);
        public double Change => _sumReceived - Total;

    }
}
