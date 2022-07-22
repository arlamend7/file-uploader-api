using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Domain.Base.Repositories
{
    public interface IRepository
    {
        public void Insert(IEnumerable<object> entities, OperadoraEnum operadora);
    }
}
