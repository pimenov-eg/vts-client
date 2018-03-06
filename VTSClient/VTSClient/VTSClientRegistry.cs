using Autofac;
using VTSClient.Services;

namespace VTSClient
{
    public class VTSClientRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServicesRegistry>();
            builder.RegisterModule<DALRegistry>();
        }
    }
}
