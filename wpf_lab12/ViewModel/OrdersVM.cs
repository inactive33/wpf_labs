using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lab12.Model;

namespace wpf_lab12.ViewModel
{
    internal class OrdersVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public OrdersVM()
        {
            _pageModel = new PageModel();
        }
    }
}
