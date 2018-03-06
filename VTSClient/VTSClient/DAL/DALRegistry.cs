using Autofac;
using VTSClient.DAL;

namespace VTSClient.Services
{
    public class DALRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new VTSDataAccessImp()).As<IVTSDataAccess>();
        }
    }
}