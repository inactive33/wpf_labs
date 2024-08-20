using wpf_lab12.Utilities;
using System.Windows.Input;

namespace wpf_lab12.ViewModel
{
    internal class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand AdminCommand { get; set; }
        public ICommand GoodsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand CustomersCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Admin(object obj) => CurrentView = new AdminVM();
        private void Goods(object obj) => CurrentView = new GoodsVM();
        private void Orders(object obj) => CurrentView = new OrdersVM();
        private void Customers(object obj) => CurrentView = new CustomersVM();


        public NavigationVM()
        {
           HomeCommand = new RelayCommand(Home);
           AdminCommand = new RelayCommand(Admin);
           GoodsCommand = new RelayCommand(Goods);
           OrdersCommand = new RelayCommand(Orders);
           CustomersCommand = new RelayCommand(Customers);
           // Startup Page
           CurrentView = new HomeVM();
        }
    }
}
