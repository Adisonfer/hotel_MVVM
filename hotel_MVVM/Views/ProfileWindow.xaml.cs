using hotel_MVVM.ViewModels;
using Interfaces.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hotel_MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        IUserService userService = App.Kernel.Get<IUserService>();
        MainWindow _wndMain;

        public ProfileWindow(MainWindow wnd, IRoomService roomService, IClientService clientService)
        {
            InitializeComponent();
            ProfileViewModel viewModel = new ProfileViewModel(this, roomService, clientService, userService);
            this.DataContext = viewModel;
            _wndMain = wnd;
            Closing += ProfileWindow_Closing;
        }

        public void CloseWnd()
        {
            _wndMain.Show();
            Close();
        }
        public void ToLoginWnd()
        {

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
            _wndMain.Close();
        }

        private void ProfileWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _wndMain.Show();
        }

    }
}
