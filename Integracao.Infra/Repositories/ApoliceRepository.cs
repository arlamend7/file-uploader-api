using Integracao.Domain.Apolices.Entities;
using Integracao.Domain.Base.Repositories;

namespace Integracao.Infra.Repositories
{
    public class ApoliceRepository : IRepository
    {
        public void Insert(IEnumerable<object> apolices)
        {
            var apolicesList = apolices as IEnumerable<Apolice>;
        }
    }
}
