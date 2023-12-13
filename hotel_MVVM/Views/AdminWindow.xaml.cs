using hotel_MVVM.Infrastructure.Services.Interfaces;
using hotel_MVVM.ViewModels;
using Interfaces.Services;
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
        public AdminWindow(IRoomService roomService)
        {
            InitializeComponent();
            AdminViewWindow adminViewModel = new AdminViewWindow(roomService);
            this.DataContext = adminViewModel;
        }

        private void btn_CreateWindow_Click(object sender, RoutedEventArgs e)
        {
            AddAdminWindow addAdmin = new AddAdminWindow();
            addAdmin.Owner = this;
            addAdmin.ShowDialog();
        }
    }
}
