using FluentNHibernate.Mapping;
using Integracao.Domain.BeneficiariosFamiliares.Entities;

namespace Integracao.Infra.Mappings
{
    public class BeneficiariosFamiliaresMap : ClassMap<BeneficiarioFamiliar>
    {
        public BeneficiariosFamiliaresMap()
        {
            Table("BeneficiariosFamiliares");
            Id(x => x.Id).Column("BeneficiarioFamiliarId");
            References(x => x.Beneficiario).Column("BeneficiarioId");
            References(x => x.Titular).Column("TitularId");
            Map(x => x.CodigoParentesco);
            Map(x => x.GrupoFamiliar);
        }
    }
}
