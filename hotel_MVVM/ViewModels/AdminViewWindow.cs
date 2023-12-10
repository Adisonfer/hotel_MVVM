using hotel_MVVM.ViewModels.Base;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_MVVM.ViewModels
{
    public class AdminViewWindow : ViewModel
    {
        private IRoomService _roomService;
        public AdminViewWindow(IRoomService roomService) { 
            _roomService = roomService;
        }
    }
}
