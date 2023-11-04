using hotel_MVVM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_MVVM.ViewModels
{
    internal class LoginViewModel : ViewModel
    {
        readonly LoginViewModel _loginViewModel = new LoginViewModel();
        readonly MainViewModel _menuViewModel = new MainViewModel();

        private ViewModel _currentViewModel;
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        //Just for test
        public void switchView()
        {
            if (CurrentViewModel == _loginViewModel) { CurrentViewModel = _menuViewModel; }
            else { CurrentViewModel = _loginViewModel; }
        }
    }
}
