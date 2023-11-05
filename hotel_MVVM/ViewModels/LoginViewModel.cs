using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        public ICommand OpenSecondWindowCommand { get; }
        private Window currentWindow;

        public LoginViewModel(Window window)
        {
            currentWindow = window;
            OpenSecondWindowCommand = new RelayCommand(OpenSecondWindow);
        }

        private void OpenSecondWindow(object p)
        {
            MainViewModel secondViewModel= new MainViewModel();
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = secondViewModel;
            mainWindow.Show();

            currentWindow.Close();
        }
    }
}
