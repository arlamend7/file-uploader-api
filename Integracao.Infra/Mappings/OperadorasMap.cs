using FluentNHibernate.Mapping;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Infra.Mappings
{
    public class OperadorasMap: ClassMap<Operadora>
    {

        public OperadorasMap()
        {
            Table("Operadoras");
            Id(x => x.Id).Column("OperadoraId");
            Map(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao");
        }
    }
}
