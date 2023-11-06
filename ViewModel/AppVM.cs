using Restaurant.Model;
using Restaurant.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Restaurant.ViewModel
{
    public class AppVM : PropertyChangedClass
    {
        private ContentControl contentCtrl;
        public ContentControl ContentCtrl
        {
            get
            {
                if (contentCtrl == null) {contentCtrl = new MenuPage(); };
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

        
    }
}
