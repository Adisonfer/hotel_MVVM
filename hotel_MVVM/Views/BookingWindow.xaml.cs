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
        IServiceService serviceService = App.Kernel.Get<IServiceService>();
        IServiceBookingService serviceBookingService = App.Kernel.Get<IServiceBookingService>();

        public BookingWindow(DateTime checkInDate, DateTime checkOutDate, int roomId)
        {
            InitializeComponent();
            viewModel = new BookingViewModel(roomService, bookingService,
               serviceService, serviceBookingService,
                checkInDate,  checkOutDate, roomId);
            DataContext = viewModel;
        }
    }
}
