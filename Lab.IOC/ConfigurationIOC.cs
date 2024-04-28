
using Autofac;
using Lab.Data.Repositories;
using Lab.Domain.Interface.IRepository;
using Lab.Domain.Interface.IService;
using Lab.Domain.Service;

namespace Lab.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterGeneric(typeof(BaseRepository<>))
               .As(typeof(IRepositoryBase<>))
               .InstancePerLifetimeScope();

            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>();

            //Escola
            builder.RegisterType<EscolaService>().As<IEscolaService>();
            builder.RegisterType<EscolaRepository>().As<IEscolaRepository>();

            #endregion IOC
        }

    }
}
