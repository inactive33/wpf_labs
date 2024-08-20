using System;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lab12.SQL;
using System.Windows;

namespace wpf_lab12.Utilities
{
    internal class DataCommands : BindableBase
    {
        AppBaseEntities1 contextDB = new AppBaseEntities1();

        public DelegateCommand UpdateTableCommand { get { return _updateTableCommand; } set { _updateTableCommand = value; } }
        public ObservableCollection<customers> CustomersData { get; set; }
        
        private DelegateCommand _updateTableCommand;

        private void Update()
        {

        }
        private void UpdateTableCommandRealization()
        {
            CustomersData.Clear();
            AppBaseEntities1 contextDB = new AppBaseEntities1();
            var DataTable = contextDB.customers.ToList();
            CustomersData.Clear();
            foreach (var customer in DataTable)
            {
                CustomersData.Add(customer);
            }
        }
        public DataCommands ()
        {
            UpdateTableCommand = new DelegateCommand(UpdateTableCommandRealization, () => true);
            CustomersData = new ObservableCollection<customers>();
            UpdateTableCommandRealization();
        }

    }
}
