using hotel_MVVM.Infrastructure.Commands;
using hotel_MVVM.Infrastructure.Services.Interfaces;
using hotel_MVVM.ViewModels.Base;
using Interfaces.DTO;
using Interfaces.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace hotel_MVVM.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IAdminService _adminService;

        private string _login;
        private string _password;

        public ICommand OpenNextWindowCommand { get; }
        public string Login {
            get => _login;
            set
            {
                if (!Set(ref _login, value)) return;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (!Set(ref _password, value)) return;
            }
        }

        public LoginViewModel(INavigationService navigationService, IUserService userService,
            IClientService clientService, IAdminService adminService)
        {
            this.navigationService = navigationService;
            _userService = userService;
            _clientService = clientService;
            _adminService = adminService;
            OpenNextWindowCommand = new RelayCommand(OpenNextWindow);
        }

        private void OpenNextWindow(object parameter)
        {
            List<UserDTO> users = _userService.GetAllUsers();
            List<ClientDTO> clients = _clientService.GetAllClients();
            List<AdminDTO> admins = _adminService.GetAllAdmins();

            foreach (UserDTO user in users)
            {
                if (user.Login == _login && user.Password == _password)
                {
                    foreach (ClientDTO client in clients)
                    {
                        if (client.UserID == user.ID)
                        {
                            navigationService.OpenNextWindow(false);
                            break;
                        }
                    }
                    foreach (AdminDTO admin in admins)
                    {
                        if (admin.UserID == user.ID) { navigationService.OpenNextWindow(true); break; }
                    }
                    break;
                }
            }
        }
    }
}
