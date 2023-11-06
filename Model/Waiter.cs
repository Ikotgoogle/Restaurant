using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class Waiter : PropertyChangedClass
    {
        private int _id;
        private string _name;
        private string _secondName;
        private string _thirdName;
        private string _post;
        private int _salary;

        public int Id{
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name { 
            get { return _name; } 
            set { _name = value; OnPropertyChanged(nameof(Name)); } 
        }

        public string SecName{
            get { return _secondName; }
            set { _secondName = value; OnPropertyChanged(nameof(SecName)); }
        }

        public string ThirdName{
            get { return _thirdName; }
            set { _thirdName = value; OnPropertyChanged(nameof(ThirdName)); }
        }

        public string Post{
            get { return _post; }
            set { _post = value; OnPropertyChanged(nameof(Post)); }
        }

        public int Salary{ 
            get { return _salary; } 
            set { _salary = value; OnPropertyChanged(nameof(Salary)); } 
        }
    }
}
