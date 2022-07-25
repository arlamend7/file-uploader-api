using FluentNHibernate.Mapping;
using Integracao.Domain.Beneficiarios.Entities;

namespace Integracao.Infra.Mappings
{
    public class BeneficiariosMap : ClassMap<Beneficiario>
    {
        public BeneficiariosMap()
        {
            Table("Beneficiario");
            CompositeId()
                .KeyProperty(x => x.Codigo, "BenificiarioId")
                .KeyReference(x=>x.Operadora,"OperadoraId");
            Map(x => x.NomeDaMae);
            Map(x => x.Nome);
            Map(x => x.NumeroCNS);
            Map(x => x.CPF);
            Map(x => x.CPFTitular);
            Map(x => x.DataNascimento);
            Map(x => x.Sexo);
            Map(x => x.Parentesco);
            Map(x => x.Remido);
            Map(x => x.IsDependente);
            References(x => x.Importacao).Column("ImportacaoId");

        }
    }
}
