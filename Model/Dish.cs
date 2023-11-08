namespace Restaurant.Model
{
    public class Dish : PropertyChangedClass
    {
        private int _dishId;
        private string _dishName;
        private string _dishDesc;
        private string _dishType;
        private int _dishCalorie;
        private double _dishProtein; // белки
        private double _dishFats; // жиры
        private double _dishCarbs; // углеводы
        private double _dishPrice;

        public int DishId
        {
            get { return _dishId; }
            set { _dishId = value; OnPropertyChanged(nameof(DishId)); }
        }

        public string DishName
        {
            get { return _dishName; }
            set { _dishName = value; OnPropertyChanged(nameof(DishName)); }
        }

        public string DishDesc
        {
            get { return _dishDesc; }
            set { _dishDesc = value; OnPropertyChanged(nameof(DishDesc)); }
        }

        public string DishType
        {
            get { return _dishType; }
            set { _dishType = value; OnPropertyChanged(nameof(DishType)); }
        }

        public int DishCalorie
        {
            get { return _dishCalorie; }
            set { _dishCalorie = value; OnPropertyChanged(nameof(DishCalorie)); }
        }

        public double DishProtein
        {
            get { return _dishProtein; }
            set { _dishProtein = value; OnPropertyChanged(nameof(DishProtein)); }
        }

        public double DishFats
        {
            get { return _dishFats; }
            set { _dishFats = value; OnPropertyChanged(nameof(DishFats)); }
        }

        public double DishCarbs
        {
            get { return _dishCarbs; }
            set { _dishCarbs = value; OnPropertyChanged(nameof(DishCarbs)); }
        }

        public double DishPrice
        {
            get { return _dishPrice; }
            set { _dishPrice = value; OnPropertyChanged(nameof(DishPrice)); }
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{DishId} {DishName} {DishType}";
        }
    }
}
