using System.Windows.Controls;
using wpf_lab12.Utilities;

namespace wpf_lab12.View
{
    /// <summary>
    /// Логика взаимодействия для Customers.xaml
    /// </summary>

    public partial class Customers : UserControl
    {
        public Customers()
        {
            InitializeComponent();
            DataContext = new DataCommands();
        }
    }
}
