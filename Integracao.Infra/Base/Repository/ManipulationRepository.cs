using Integracao.Core.Base.Entities;
using Integracao.Domain.Base.Repositories;
using NHibernate;

namespace Integracao.Infra.Base.Repository
{
    public class ManipulationRepository : IManipulationRepository
    {
        private readonly ISession _session;
        public ManipulationRepository(ISession session)
        { 
             _session = session;
        }

        public virtual long Insert<T>(T entity) where T : EntityBase
        {
            var id = (long)_session.Save(entity);
            return id;
        }

    }
}
