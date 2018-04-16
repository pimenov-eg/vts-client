using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VTSClient.Services.VTSService;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.ViewModels
{
    public class VacListViewModel : MvxViewModel
    {
        private readonly IVTSService _service;
        private readonly IMvxNavigationService _navigationService;

        public MvxObservableCollection<VacationRequest> VacationRequests { get; set; }

        public IMvxAsyncCommand VacSelectedCommand => new MvxAsyncCommand(VacSelectedHandler);

        public IMvxAsyncCommand AddVacCommand => new MvxAsyncCommand(AddVacHandler, () => true);

        private async Task VacSelectedHandler()
        {
            // TODO
        }

        private async Task AddVacHandler()
        {
            // TODO
        }

        public VacListViewModel(IVTSService service, IMvxNavigationService navigationService)
        {
            _service = service;
            _navigationService = navigationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            var allVacations = _service.GetAllVacations().Result;
            VacationRequests = new MvxObservableCollection<VacationRequest>(allVacations.Vacations);
        }
    }
}