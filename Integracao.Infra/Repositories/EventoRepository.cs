using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Eventos.Entities;

namespace Integracao.Infra.Repositories
{
    public class EventoRepository : IRepository
    {
        public void Insert(IEnumerable<object> eventos)
        {
            var eventosList = eventos as IEnumerable<Evento>;

        }
    }
}
