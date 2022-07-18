using FluentNHibernate.Mapping;
using Integracao.Domain.Servicos.Entities;

namespace Integracao.Infra.Mappings
{
    public class ServicosMap : ClassMap<Servico>
    {
        public ServicosMap()
        {
            Table("Servicos");
            Id(x => x.Id);
            Map(x => x.Codigo).Column("Codigo");
            Map(x => x.Descricao).Column("Descricao");
            References(x => x.Operadora).Column("OperadoraId");
            References(x => x.Principal).Column("PrincipalId");
        }
    }
}
