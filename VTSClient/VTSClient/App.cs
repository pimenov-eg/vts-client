using Autofac;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService;
using VTSClient.ViewModels;

namespace VTSClient
{
    public class App : MvxApplication
    {
        public ContainerBuilder ContainerBuilder { get; }

        public App()
        {
            Mvx.RegisterType<IVTSService, VTSServiceImp>();
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());

            //ContainerBuilder = new ContainerBuilder();
            //ContainerBuilder.RegisterModule<VTSClientRegistry>();
            //
            //ContainerBuilder
            //    .Register(c => new MvxAppStart<LoginViewModel>()).As<IMvxAppStart>()
            //    .SingleInstance();
            //
            //ContainerBuilder.Build();
        }
    }
}