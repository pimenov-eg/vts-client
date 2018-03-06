using Autofac;
using NUnit.Framework;
using System;
using System.Linq;
using VTSClient.Services.VTSService;
using VTSClient.Services.VTSService.DTO;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<VTSClientRegistry>();
            var container = containerBuilder.Build();

            var vtsService = container.Resolve<IVTSService>();

            GetAllVacationCheck(vtsService, 5);
            CreateNewVacationCheck(vtsService);

            Console.WriteLine("Everything is OK...");
            Console.ReadLine();
        }

        private static void GetAllVacationCheck(IVTSService vtsService, int expectedCount)
        {
            var allVacations = vtsService.GetAllVacations().Result.Vacations;
            Assert.That(allVacations.Count, Is.GreaterThan(0));
        }

        private static void CreateNewVacationCheck(IVTSService vtsService)
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

            var reloadedVacation = vtsService.UpdateVacation(newVacation).Result.Vacation;

            Assert.That(reloadedVacation, Is.Not.Null);
            Assert.That(reloadedVacation.Id, Is.EqualTo(newVacationId));
        }

        private static void ShowVacation(VacationRequest vacation)
        {
            Console.WriteLine($"{vacation.Id}," +
                $" {vacation.Start.ToShortDateString()}," +
                $" {vacation.End.ToShortDateString()}," +
                $" {vacation.VacationStatus}," +
                $" {vacation.VacationType}," +
                $" {vacation.CreatedBy}," +
                $" {vacation.Created.ToShortDateString()}" +
                $"{Environment.NewLine}");

        }
    }
}
