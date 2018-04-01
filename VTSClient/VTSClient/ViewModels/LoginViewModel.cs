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

        private bool isNotificatinMessageVisible;
        public bool IsNotificatinMessageVisible
        {
            get => isNotificatinMessageVisible;
            set
            {
                isNotificatinMessageVisible = value;
                RaisePropertyChanged(() => IsNotificatinMessageVisible);
            }
        }

        public IMvxCommand LoginCommand => new MvxCommand(Login);

        private void Login()
        {
            var test = _service.GetAllVacations().Result.Vacations;

            bool isLoggedIn = _service.Login(LoginName, Password).Result;
            IsNotificatinMessageVisible = !isLoggedIn;


            // TODO novigate
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
