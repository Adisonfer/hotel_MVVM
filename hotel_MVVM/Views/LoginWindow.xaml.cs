using hotel_MVVM.Infrastructure.Services.Interfaces;
using hotel_MVVM.ViewModels;
using System;
using System.Windows;


namespace hotel_MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, INavigationService
    {
        private LoginViewModel viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel(this);
            DataContext = viewModel;
        }

        public void OpenNextWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel secondViewModel = new MainViewModel(mainWindow);
            mainWindow.DataContext = secondViewModel;
            mainWindow.Show();

            this.Close();
        }
    }
}
