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
            MainWindow mainWindow = new MainWindow();
            MainViewModel secondViewModel = new MainViewModel(mainWindow);
            mainWindow.DataContext = secondViewModel;
            mainWindow.Show();

            currentWindow.Close();
        }
    }
}
