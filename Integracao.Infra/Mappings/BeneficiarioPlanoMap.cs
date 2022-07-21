using FluentNHibernate.Mapping;
using Integracao.Domain.Beneficiarios.Entities;

namespace Integracao.Infra.Mappings
{
    public class BeneficiarioPlanoMap : ClassMap<BeneficiarioPlano>
    {
        public BeneficiarioPlanoMap()
        {
            Table("BeneficiarioPlano");
            Id(x => x.Codigo);
            Map(x => x.CodigoBeneficiario).Column("BeneficiarioId");
            Map(x => x.CodigoPlano).Column("PlanoId");
            Map(x => x.NumeroApolice);
            Map(x => x.UF);
            Map(x => x.Cidade);
            Map(x => x.Inicio);
            Map(x => x.Fim);
            Map(x => x.DataMaxPermanencia);
            Map(x => x.DataDemissaoOuAposentadoria);
            Map(x => x.Acomodacao);
            Map(x => x.IsDemitidoOuAposentado);
            Map(x => x.RazaoSocial);
            Map(x => x.CodigoEmpresa);
         

        }
    }
}
