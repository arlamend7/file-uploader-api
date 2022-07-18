using Integracao.Core.Base.Entities;
using Integracao.Domain.Base.Repositories;
using NHibernate;
using System.Linq.Expressions;

namespace Integracao.Infra.Base.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ISession _session;
        public QueryRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> Query<T>() where T : EntityBase
        {
            return _session.Query<T>();
        }

        public T Get<T>(long id) where T : EntityBase
        {
            return _session.Get<T>(id);
        }

        public T Get<T>(Expression<Func<T, bool>> expression) where T : EntityBase
        {
            return Query<T>().SingleOrDefault(expression);    
        }



    }
}
