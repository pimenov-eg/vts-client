using Autofac;
using VTSClient.DAL;

namespace VTSClient.Tests.DAL
{
    public class DALRegistryTest : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new VTSDataAccessImpTest()).As<IVTSDataAccess>();
        }
    }
}