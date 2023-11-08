using Restaurant.Model;
using Restaurant.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Restaurant.ViewModel
{
    public class AppVM : PropertyChangedClass
    {
        public ObservableCollection<Dish> Dishes { get; set; }
        public ObservableCollection<Waiter> Waiters { get; set; }
        public ObservableCollection<Table> Tables { get; set; }
        #region Selection
        private Dish selectedDish;
        public Dish SelectedDish
        {
            get => selectedDish;
            set { selectedDish = value; OnPropertyChanged(nameof(SelectedDish)); }
        }

        private Waiter selectedWaiter;
        public Waiter SelectedWaiter
        {
            get => selectedWaiter;
            set { selectedWaiter = value; OnPropertyChanged(nameof(SelectedWaiter)); }
        }

        private Table selectedTable;
        public Table SelectedTable
        {
            get => selectedTable;
            set { selectedTable = value; OnPropertyChanged(nameof(SelectedTable)); }
        }
        #endregion
        #region Searching 
        private string findingDishText;
        public string FindingDishText
        {
            get => findingDishText;
            set { findingDishText = value; OnPropertyChanged(nameof(FindingDishText)); OnPropertyChanged(nameof(FoundDishes)); }
        }

        private string findingWaiterText;
        public string FindingWaiterText
        {
            get => findingWaiterText;
            set { findingWaiterText = value; OnPropertyChanged(nameof(FindingWaiterText)); OnPropertyChanged(nameof(FoundWaiters)); }
        }

        private string findingTableText;
        public string FindingTableText
        {
            get => findingTableText;
            set { findingTableText = value; OnPropertyChanged(nameof(FindingTableText)); OnPropertyChanged(nameof(FoundTables)); }
        }

        private string addingDishText;
        public string AddingDishText
        {
            get => addingDishText;
            set { addingDishText = value; OnPropertyChanged(nameof(AddingDishText)); }
        }
        #endregion

        public string DishTitle{
            get{
                if (selectedDish != null){
                    return selectedDish.DishName;
                } else return "";
            }
        }

       /* public int NumsPerson{
            get{
                if (selectedTable != null){
                    return selectedTable.VisitorNum;
                }
                else return 0;
            }
            set{
                selectedTable.VisitorNum = value;
            }
        }*/

        public ObservableCollection<Dish> FoundDishes{
            get{
                if (findingDishText != null){
                    return new ObservableCollection<Dish>(Dishes.Where(dish => dish.ToString().IndexOf(FindingDishText, System.StringComparison.OrdinalIgnoreCase) >= 0));
                } else return Dishes;
            }
        }

        public ObservableCollection<Waiter> FoundWaiters{
            get{
                if (findingWaiterText != null){
                    return new ObservableCollection<Waiter>(Waiters.Where(waiter => waiter.ToString().IndexOf(FindingWaiterText, System.StringComparison.OrdinalIgnoreCase) >= 0));
                } else return Waiters; 
            }
        }

        public ObservableCollection<Table> FoundTables{
            get{
                if (findingTableText != null){
                    return new ObservableCollection<Table>(Tables.Where(table => table.ToString().IndexOf(FindingTableText, System.StringComparison.OrdinalIgnoreCase) >= 0));
                } else return Tables;
            }
        }

        public ObservableCollection<Dish> FoundDishToAdd{
            get{
                if (addingDishText != null){
                    return new ObservableCollection<Dish>(Dishes.Where(dish => dish.ToString().IndexOf(FindingDishText, System.StringComparison.OrdinalIgnoreCase) >= 0));
                } else return Dishes;
            }
        }


        #region DataBase
        public AppVM()
        {
            Dishes = new ObservableCollection<Dish>
            {
                new Dish{ DishId = 0, DishName = "Папа Карло", DishDesc = "Пицца от шеф-повара, выпекается в форме сердца!", DishType = "Пицца", DishCalorie = 211, DishProtein = 11, DishFats = 8.8, DishCarbs = 21.7, DishPrice = 580},
                new Dish{ DishId = 1, DishName = "Пепперони", DishDesc = "Классическая пицца пепперони.", DishType = "Пицца", DishCalorie = 238, DishProtein = 12.4, DishFats = 10.7, DishCarbs = 22.9, DishPrice = 540},
                new Dish{ DishId = 2, DishName = "Ветчина и грибы", DishDesc = "Пицца с ветчиной и грибами.", DishType = "Пицца", DishCalorie = 195, DishProtein = 15.6, DishFats = 10.2, DishCarbs = 20.5, DishPrice = 490},
                new Dish{ DishId = 3, DishName = "Лазанья мясная", DishDesc = "Паста, запеченная слоями с мясным фаршем, томатным и сливочным соусом, с сыром моцарелла и пармезан", DishType = "Паста", DishCalorie = 79, DishProtein = 5.9, DishFats = 3.6, DishCarbs = 2.9, DishPrice = 440},
                new Dish{ DishId = 4, DishName = "Верона", DishDesc = "Пенне с индейкой, баклажанами в сливочно-томатном соусе с добавлением сыра пармезан и кедровых орехов", DishType = "Паста", DishCalorie = 300, DishProtein = 18.3, DishFats = 8.2, DishCarbs = 25.1, DishPrice = 440},
                new Dish{ DishId = 5, DishName = "Крем-суп Грибной", DishDesc = "Крем суп с шампиньонами, картофелем, белым луком и сливками, подается с ароматными гренками", DishType = "Суп", DishCalorie = 84, DishProtein = 1.7, DishFats = 6.7, DishCarbs = 4.2, DishPrice = 260},
                new Dish{ DishId = 6, DishName = "Крем-суп Сырный", DishDesc = "Крем-суп со сливочным сыром, картофелем и морковью, подается с ароматными гренками", DishType = "Суп", DishCalorie = 193, DishProtein = 9.4, DishFats = 21.7, DishCarbs = 15.5, DishPrice = 260},
                new Dish{ DishId = 7, DishName = "Суп с морепродуктами", DishDesc = "Пикатный вкус, сливки, креветки, мидии, шампиньоны, протертые томаты.", DishType = "Суп", DishCalorie = 101, DishProtein = 4.1, DishFats = 8.4, DishCarbs = 2.5, DishPrice = 320},
                new Dish{ DishId = 8, DishName = "Витербо", DishDesc = "Ростбиф, салат ромейн, листья шпината, помидорки черри, сыр фетаки, ореховая заправка, украшается кедровыми орехами", DishType = "Салат", DishCalorie = 132, DishProtein = 3.9, DishFats = 12, DishCarbs = 2.3, DishPrice = 480},
                new Dish{ DishId = 9, DishName = "Больцано", DishDesc = "Баклажаны, помидорки черри, сушеные помидоры, шампиньоны, руккола и апельсиновая заправка", DishType = "Салат", DishCalorie = 167, DishProtein = 2.2, DishFats = 15.8, DishCarbs = 3.6, DishPrice = 330},
                new Dish{ DishId = 10, DishName = "Палермо", DishDesc = "Креветки, смесь салатов, помидоры, сладкий перец, петрушка, имбирная заправка", DishType = "Салат", DishCalorie = 89, DishProtein = 4.1, DishFats = 6.2, DishCarbs = 4.2, DishPrice = 400},
                new Dish{ DishId = 11, DishName = "Фокачча с кунжутом", DishDesc = "Моцарелла, оливковое масло, кунжут", DishType = "Хлеб", DishCalorie = 298, DishProtein = 8.6, DishFats = 12.6, DishCarbs = 37.5, DishPrice = 160},
                new Dish{ DishId = 12, DishName = "Чесночный", DishDesc = "Итальянский хлеб с ароматом чеснока", DishType = "Хлею", DishCalorie = 147, DishProtein = 2.7, DishFats = 14.6, DishCarbs = 1.3, DishPrice = 170},
                new Dish{ DishId = 13, DishName = "Тирамису", DishDesc = "Печенье савоярди, сыр маскарпоне, сливки, кофе", DishType = "Десерт", DishCalorie = 467, DishProtein = 6.6, DishFats = 30.5, DishCarbs = 41.2, DishPrice = 330},
                new Dish{ DishId = 14, DishName = "Канноли", DishDesc = "Сицилийская трубочка, сыр рикотта, цукаты, фисташки", DishType = "Десерт", DishCalorie =  167, DishProtein = 2.4, DishFats = 13.1, DishCarbs = 9.8, DishPrice = 200}
            };

            Waiters = new ObservableCollection<Waiter>
            {
                new Waiter { Id = 0, Name = "Иван", SecName = "Лебедев", ThirdName = "Дмитриевич", Post = "Старший официант", Salary = 35700},
                new Waiter { Id = 1, Name = "Мария", SecName = "Соколова", ThirdName = "Сергеевна", Post = "Старший официант", Salary = 35700},
                new Waiter { Id = 2, Name = "Михаил", SecName = "Козлов", ThirdName = "Петрович", Post = "Официант", Salary = 28900},
                new Waiter { Id = 3, Name = "Светлана", SecName = "Рогачева", ThirdName = "Максимовна", Post = "Официант", Salary = 26200},
                new Waiter { Id = 4, Name = "Максим", SecName = "Леонидович ", ThirdName = "Лавров ", Post = "Стажер", Salary = 23100},
            };

            Tables = new ObservableCollection<Table> {
                new Table { Id = 0, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 1, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 2, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 3, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 4, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 5, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 6, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 7, VisitorNum = 0, Dishes = { }, Bill = 0 },
                new Table { Id = 8, VisitorNum = 0, Dishes = { }, Bill = 0 }
            };
        }
        #endregion
        #region SetUpPage
        private ContentControl contentCtrl;
        public ContentControl ContentCtrl
        {
            get
            {
                if (contentCtrl == null) { contentCtrl = new MenuPage(); };
                return contentCtrl;
            }
            set { contentCtrl = value; OnPropertyChanged(nameof(ContentCtrl)); }
        }

        private RelayCommand setUpPage;
        public RelayCommand SetUpPage
        {
            get
            {
                return setUpPage ?? (setUpPage = new RelayCommand(obj =>
                {
                    if ((obj as string) == "MenuButton") ContentCtrl = new MenuPage();
                    if ((obj as string) == "PersonalButton") ContentCtrl = new StaffPage();
                    if ((obj as string) == "TablesButton") ContentCtrl = new ServicePage();
                }));
            }
        }
        #endregion
    }
}
