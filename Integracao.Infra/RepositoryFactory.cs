using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Infra.Repositories;

namespace Integracao.Infra
{
    public class RepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryFactory(IServiceProvider serviceProvider)
        {
             _serviceProvider = serviceProvider;
        }

        public IRepository Config(Type type)
        {
            return (IRepository)_serviceProvider.GetService(type switch
            {
                Type typeCase when typeCase == typeof(Beneficiario) => typeof(BeneficiarioRepository),
                _ => throw new NotImplementedException()
            });
        }
    }
}
