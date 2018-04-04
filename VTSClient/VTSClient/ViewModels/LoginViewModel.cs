using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService;

namespace VTSClient.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IVTSService _service;
        private readonly IMvxNavigationService _navigationService;

        private string loginName;
        public string LoginName
        {
            get => loginName;
            set
            {
                loginName = value;
                RaisePropertyChanged(() => LoginName);
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private bool isLoggedIn = true;
        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set
            {
                isLoggedIn = value;
                RaisePropertyChanged(() => IsLoggedIn);
            }
        }

        public string IsNotLoggedMessage => "Please, retry your login and password pair. Check current Caps Lock and input language settings";

        public IMvxAsyncCommand LoginCommand => new MvxAsyncCommand(Login);

        private async Task Login()
        {
            IsLoggedIn = await _service.Login(LoginName, Password);
            if (IsLoggedIn)
            {
                await _navigationService.Navigate<VacListViewModel>();
            }
        }

        public LoginViewModel(IVTSService service, IMvxNavigationService navigationService)
        {
            _service = service;
            _navigationService = navigationService;
        }
    }
}