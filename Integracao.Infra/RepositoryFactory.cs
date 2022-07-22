using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Eventos.Entities;
using Integracao.Domain.Planos.Entidades;
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
            return (IRepository)_serviceProvider.GetService(type.Name switch
            {
                nameof(Beneficiario) => typeof(BeneficiarioRepository),
                nameof(Evento) => typeof(EventoRepository),
                nameof(Plano) => typeof(PlanoRepository),
                nameof(BeneficiarioPlano) => typeof(BeneficiarioPlano),
                _ => throw new NotImplementedException()
            });
        }
    }
}
