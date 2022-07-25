using FluentNHibernate.Mapping;
using Integracao.Domain.Planos.Entidades;

namespace Integracao.Infra.Mappings
{
    public class PlanoMap : ClassMap<Plano>
    {
        public PlanoMap()
        {
            Table("Plano");
            CompositeId()
                .KeyProperty(x => x.Codigo, "PlanoId")
                .KeyReference(x => x.Operadora, "OperadoraId");
            Map(x => x.Descricao);
            References(x => x.Importacao).Column("ImportacaoId");

        }
    }
}
