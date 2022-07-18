using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Base.Repositories
{
    public interface IRepository
    {
        public void Insert(IEnumerable<object> entities);
    }
}
