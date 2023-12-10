using hotel_MVVM.Infrastructure.Services.Interfaces;
using hotel_MVVM.Utils;
using hotel_MVVM.ViewModels;
using Interfaces.Services;
using Ninject;
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
            IRoomService roomService = App.Kernel.Get<IRoomService>();

            MainWindow mainWindow = new MainWindow(roomService);

            mainWindow.Show();
            this.Close();
        }
    }
}
