using hotel_MVVM.ViewModels;
using hotel_MVVM.Views;
using Interfaces.Services;
using System.Windows;


namespace hotel_MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRoomService roomService;
        IClientService clientService;
        public MainWindow(IRoomService roomService, IClientService clientService)
        {
            InitializeComponent();
            this.roomService = roomService;
            this.clientService = clientService;
            var loginViewModel = new MainViewModel(this, roomService, clientService);
            this.DataContext = loginViewModel;
        }
        public void OpenProfileWindow()
        {
            ProfileWindow window = new ProfileWindow(this, roomService, clientService);

            window.Show();
            this.Hide();
        }
    }
}
