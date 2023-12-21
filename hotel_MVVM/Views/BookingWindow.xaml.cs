using hotel_MVVM.ViewModels.Base;
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
    public partial class BookingWindow : Window
    {
        BookingViewModel viewModel;
        IRoomService roomService = App.Kernel.Get<IRoomService>();
        IBookingService bookingService = App.Kernel.Get<IBookingService>();
        IAdditionService additionService = App.Kernel.Get<IAdditionService>();
        IBookingAddition serviceBookingService = App.Kernel.Get<IBookingAddition>();

        public BookingWindow(DateTime checkInDate, DateTime checkOutDate, int roomId, IClientService clientService)
        {
            InitializeComponent();
            viewModel = new BookingViewModel(roomService, bookingService,
               additionService, serviceBookingService, clientService,
                checkInDate,  checkOutDate, roomId);
            DataContext = viewModel;
        }
    }
}
