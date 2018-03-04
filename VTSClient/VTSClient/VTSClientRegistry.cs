using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VTSClient.Services;

namespace VTSClient
{
    public class VTSClientRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServicesRegistry>();
        }
    }
}
