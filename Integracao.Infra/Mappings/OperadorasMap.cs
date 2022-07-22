using FluentNHibernate.Mapping;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Infra.Mappings
{
    public class OperadorasMap: ClassMap<Operadora>
    {

        public OperadorasMap()
        {
            Table("Operadora");
            Id(x => x.Codigo).Column("OperadoraId");
            Map(x => x.Descricao).Column("Descricao");
        }
    }
}
