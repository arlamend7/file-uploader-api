using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Integracao.Infra.DatabaseConfig
{
    public static class DbConfig
    {
        public static ISessionFactory CreateSession<T>( string path)
{
            IPersistenceConfigurer persistenceConfiguration = PersistenceConfiguration(path);

            return Fluently.Configure()
                .Database(persistenceConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(false, true);
                })
                .BuildConfiguration()
                .BuildSessionFactory();
        }
        private static IPersistenceConfigurer PersistenceConfiguration(string path)
        {
            return SQLiteConfiguration.Standard
                                       .UsingFile(path)
                                       .ShowSql()
                                       .FormatSql();
        }
    }
}
