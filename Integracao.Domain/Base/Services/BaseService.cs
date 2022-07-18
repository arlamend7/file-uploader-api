using Integracao.Core.Base.Entities;
using Integracao.Domain.Base.Repositories;
using Integracao.Infra.Base.Services.Interfaces;

namespace Integracao.Infra.Base.Services
{
    public class BaseService<T> where T : EntityBase, IBaseService<T>
    {
        IManipulationRepository _manipulationRepository;
        public BaseService(IManipulationRepository manipulationRepository)
        {
            _manipulationRepository = manipulationRepository;
        }

        public virtual T Insert(T entity)
        {
            long key = _manipulationRepository.Insert(entity);
            entity.SetId(key);
            return entity;
        }

        public virtual void Delete(long id)
        {
            
        }

    }
}
