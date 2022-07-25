using FluentNHibernate.Mapping;
using Integracao.Domain.Importacoes.Entities;

namespace Integracao.Infra.Mappings
{
    public class ImportacoesMap : ClassMap<Importacao>
    {
        public ImportacoesMap()
        {
            Table("Importacao");
            Id(x => x.Codigo).Column("ImportacaoId");
            Map(x => x.NomeArquivo);
            Map(x => x.Tamanho);
            Map(x => x.Classe);
            Map(x => x.Operadora).Column("OperadoraId");
            Map(x => x.InsertDate);
            Map(x => x.Month);
            Map(x => x.Year);
            Map(x => x.Identifier);

        }
    }
}
