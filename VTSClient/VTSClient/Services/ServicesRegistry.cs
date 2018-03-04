using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services.VTSService;

namespace VTSClient.Services
{
    public class ServicesRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new VTSServiceImp()).As<IVTSService>();
        }
    }
}