using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class Table : PropertyChangedClass
    {
        private int _id;
        private int _visitorNum;
        private ObservableCollection<Dish> _dishes;
        private double _bill;
        
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        } 
        
        public int VisitorNum{ 
            get { return _visitorNum; } 
            set { _visitorNum = value; OnPropertyChanged(nameof(VisitorNum)); } 
        }

        public ObservableCollection<Dish> Dishes{
            get{
                if( _dishes == null ){
                    _dishes = new ObservableCollection<Dish>();
                }
                return _dishes;
            }
            set { _dishes = value; OnPropertyChanged(nameof(Dishes)); }
        }

        public double Bill
        {
            get { return _bill; }
            set { _bill = value; OnPropertyChanged(nameof(Bill)); }
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Id}";
        }
    }
}
