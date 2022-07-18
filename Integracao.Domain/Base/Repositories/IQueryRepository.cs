using Integracao.Core.Base.Entities;
using System.Linq.Expressions;

namespace Integracao.Domain.Base.Repositories
{
    public interface IQueryRepository
    {
        IQueryable<T> Query<T>() where T : EntityBase;
        public T Get<T>(long id) where T : EntityBase;
        T Get<T>(Expression<Func<T, bool>> expression) where T : EntityBase;
    }
}
