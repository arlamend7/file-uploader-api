using FluentNHibernate.Mapping;
using Integracao.Domain.Beneficiarios.Entities;

namespace Integracao.Infra.Mappings
{
    public class BeneficiariosMap : ClassMap<Beneficiario>
    {
        public BeneficiariosMap()
        {
            Table("Beneficiario");
            Id(x => x.Id).Column("BeneficiarioId");
            Map(x => x.DataNascimento);
            Map(x => x.Sexo);
            Map(x => x.CodigoParentesco);
            Map(x => x.NomeDaMae);
            Map(x => x.Nome);
            Map(x => x.NumeroCNS);
            Map(x => x.CPF);
            Map(x => x.Carteirinha);
            Map(x => x.Empresa);
            Map(x => x.RazaoSocial);

        }
    }
}
