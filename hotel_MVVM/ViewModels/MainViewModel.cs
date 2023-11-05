using hotel_MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hotel_MVVM.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private Window _currentWindow;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MainViewModel(Window window)
        {
            _currentWindow = window;
        }
    }
}
