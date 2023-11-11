using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.Infrastructure.Services.Interfaces;
using hotel_MVVM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        public ICommand OpenNextWindowCommand { get; }

        private readonly INavigationService navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            OpenNextWindowCommand = new RelayCommand(OpenNextWindow);
        }

        private void OpenNextWindow(object parameter)
        {
            navigationService.OpenNextWindow();
        }
    }
}
