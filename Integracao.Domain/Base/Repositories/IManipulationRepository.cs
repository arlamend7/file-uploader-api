using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Base.Repositories
{
    public interface IManipulationRepository
    {
        long Insert<T>(T entity) where T : EntityBase;
    }
}
