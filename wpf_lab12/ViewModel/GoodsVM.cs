﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lab12.Model;

namespace wpf_lab12.ViewModel
{
    internal class GoodsVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public GoodsVM()
        {
            _pageModel = new PageModel();
        }
    }
}
