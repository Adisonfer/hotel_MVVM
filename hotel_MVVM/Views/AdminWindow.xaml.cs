using hotel_MVVM.ViewModels;
using Interfaces.DTO;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        IBookingService bookingService = App.Kernel.Get<IBookingService>();
        IPaymentStatusService statusService = App.Kernel.Get<IPaymentStatusService>();
        AdminViewWindow adminViewModel;
        public AdminWindow(IRoomService roomService)
        {
            InitializeComponent();
            adminViewModel = new AdminViewWindow(roomService, bookingService, statusService);
            this.DataContext = adminViewModel;
        }

        private void btn_CreateWindow_Click(object sender, RoutedEventArgs e)
        {
            AddAdminWindow addAdmin = new AddAdminWindow();
            addAdmin.Owner = this;
            addAdmin.ShowDialog(); // Открывает окно и ждет, пока оно не будет закрыто
            adminViewModel.UpdateData();
        }

        private void btn_LoginWindow_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
