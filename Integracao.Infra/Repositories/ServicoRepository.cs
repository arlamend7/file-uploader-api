using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Servicos.Entities;

namespace Integracao.Infra.Repositories
{
    public class ServicoRepository : IRepository
    {
        public void Insert(IEnumerable<object> servicos)
        {
            var servicosList = servicos as IEnumerable<Servico>;

        }
    }
}
