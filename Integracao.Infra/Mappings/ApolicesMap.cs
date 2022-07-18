using FluentNHibernate.Mapping;
using Integracao.Domain.Apolices.Entities;

namespace Integracao.Infra.Mappings
{
    public class ApolicesMap : ClassMap<Apolice>
    {
        public ApolicesMap()
        {
            Table("Apolice");
            Id(x => x.Id).Column("ApoliceId");
            Map(x => x.Codigo).Column("Codigo");
            Map(x => x.Acomodacao).Column("Acomodacao");
            Map(x => x.Produto).Column("Produto");
            Map(x => x.Plano).Column("Plano");
            Map(x => x.Setor).Column("Setor");
            Map(x => x.DataMaxPermanencia).Column("DataMaxPermanencia");
            Map(x => x.DataInativo).Column("DataInativo");
            Map(x => x.Remido).Column("Remido");
            Map(x => x.TipoBeneficiario).Column("TipoBeneficiario");
            Map(x => x.TipoSegurado).Column("TipoSegurado");
            Map(x => x.Permanencia).Column("Permanencia");
            Map(x => x.InicioPlano).Column("InicioPlano");    
            Map(x => x.FimPlano).Column("FimPlano");

         
        }
    }
}
