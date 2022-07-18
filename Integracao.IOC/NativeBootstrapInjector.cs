using Integracao.Domain.Base.Repositories;
using Integracao.Infra.Base.Repository;
using Integracao.Infra.DatabaseConfig;
using Integracao.Infra.Mappings;
using Integracao.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Integracao.IOC
{
    public class NativeBootstrapInjector
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var path = configuration.GetSection("DatabaseConn").Exists();

            var conn = configuration.GetSection("ConnectionStrings:SQLite").Value;


            services.AddSingleton(factory => DbConfig.CreateSession<EventosMap>(configuration.GetSection("DatabaseConn:Path").Value));

            services.AddScoped<BeneficiarioRepository>();
            services.AddScoped<SQLiteConnection>(x=> new SQLiteConnection(conn));
            services.AddScoped(factory => factory.GetService<ISessionFactory>().OpenSession());

            //services.AddAutoMapper(typeof(PeopleProfile).GetTypeInfo().Assembly);
            services.AddScoped<IManipulationRepository, ManipulationRepository>();
            services.AddScoped(typeof(IQueryRepository), typeof(QueryRepository));


        }


    }
}