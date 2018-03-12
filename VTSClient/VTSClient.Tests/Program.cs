using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VTSClient.DAL;
using VTSClient.Services.VTSService;
using VTSClient.Services.VTSService.DTO;
using VTSClient.Services.VTSService.Entities;
using VTSClient.Tests.DAL;

namespace VTSClient.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<VTSClientRegistry>();
            containerBuilder.RegisterModule<DALRegistryTest>();
            var container = containerBuilder.Build();

            var vtsService = container.Resolve<IVTSService>();
            var vtsDataAccess = container.Resolve<IVTSDataAccess>();
            Assert.That(vtsService, Is.Not.Null);
            Assert.That(vtsDataAccess, Is.Not.Null);

            var allVacations = GetAllVacationsFromService(vtsService);
            UpdateAllVacationsInDb(vtsDataAccess, allVacations);

            var newVacation = CreateNewVacation();
            StoreVacationInDb(vtsDataAccess, newVacation);
            UploadVacationToService(vtsService, newVacation);

            Console.WriteLine("Everything is OK...");
            Console.ReadLine();
        }

        private static List<VacationRequest> GetAllVacationsFromService(IVTSService vtsService)
        {
            var allVacations = vtsService.GetAllVacations().Result.Vacations;
            Assert.That(allVacations.Count, Is.GreaterThan(0));

            return allVacations;
        }

        private static void UpdateAllVacationsInDb(IVTSDataAccess vtsDataAccess, List<VacationRequest> allVacations)
        {
            vtsDataAccess.StoreAllVacations(allVacations);
        }

        private static void StoreVacationInDb(IVTSDataAccess vtsDataAccess, VacationRequest vacation)
        {
            var result = vtsDataAccess.StoreVacation(vacation);

            Assert.That(result, Is.EqualTo(1));
        }

        private static void UploadVacationToService(IVTSService vtsService, VacationRequest vacation)
        {
            var existingVacation = vtsService.GetVacation(vacation.Id).Result;
            Assert.That(existingVacation, Is.Null);

            var reloadedVacation = vtsService.UpdateVacation(vacation).Result.Vacation;
            Assert.That(reloadedVacation.Id, Is.EqualTo(vacation.Id));
        }

        private static VacationRequest CreateNewVacation()
        {
            var newVacationId = Guid.NewGuid();

            var newVacation = new VacationRequest
            {
                Id = newVacationId,
                Start = DateTime.Today,
                End = DateTime.Today.AddDays(7),
                Created = DateTime.Today,
                CreatedBy = "NewTestUser",
                VacationType = VacationType.Exceptional,
                VacationStatus = VacationStatus.Approved
            };

            return newVacation;
        }
    }
}