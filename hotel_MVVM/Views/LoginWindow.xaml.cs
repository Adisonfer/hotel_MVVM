using BLL.Services;
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
        IClientService clientService = App.Kernel.Get<IClientService>();
        IUserService userService = App.Kernel.Get<IUserService>();
        IAdminService adminService = App.Kernel.Get<IAdminService>();

        public LoginWindow()
        {
            InitializeComponent();
            viewModel = new LoginViewModel(this, userService, clientService, adminService);
            DataContext = viewModel;
        }

        public void OpenNextWindow(bool admin)
        {
            IRoomService roomService = App.Kernel.Get<IRoomService>();
            Window window;
            if (admin)
                window = new AdminWindow(roomService);
            else
                window = new MainWindow(roomService);
            window.Show();
            this.Close();
        }
    }
}
