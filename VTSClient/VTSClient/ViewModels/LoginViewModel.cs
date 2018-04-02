using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService;

namespace VTSClient.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IVTSService _service;

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

        public IMvxCommand LoginCommand => new MvxCommand(Login);

        private void Login()
        {
            IsLoggedIn = _service.Login(LoginName, Password).Result;
            if (IsLoggedIn)
            {
                // TODO novigate
            }
        }

        public LoginViewModel(IVTSService service)
        {
            _service = service;
        }

        public override void Start()
        {
            base.Start();
        }
    }
}