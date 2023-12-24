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
    /// Логика взаимодействия для BookingInformationWindow.xaml
    /// </summary>
    public partial class BookingInformationWindow : Window
    {
        IBookingService bookingService = App.Kernel.Get<IBookingService>();
        IBookingAddition  bookingAddition = App.Kernel.Get<IBookingAddition>();
        IAdditionService additionService = App.Kernel.Get<IAdditionService>();
        IPaymentStatusService statusService = App.Kernel.Get<IPaymentStatusService>();
        public BookingInformationWindow(int booking_id, IRoomService roomService)
        {
            InitializeComponent();
            BookingInformationViewModel viewModel = new BookingInformationViewModel(roomService, bookingService, bookingAddition, additionService, statusService, booking_id);
            this.DataContext = viewModel;
        }
    }
}
