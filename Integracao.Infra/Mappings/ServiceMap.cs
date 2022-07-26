using System;
using FluentNHibernate.Mapping;
using Integracao.Domain.Servicos.Entidades;

namespace Integracao.Infra.Mappings
{
	public class ServiceMap : ClassMap<Servico>
	{
		public ServiceMap()
		{
            Table("Servico");
            CompositeId()
                .KeyProperty(x => x.Codigo, "ServicoId")
                .KeyReference(x => x.Operadora, "OperadoraId");
            Map(x => x.Descricao);
            References(x => x.Importacao).Column("ImportacaoId");
            References(x => x.Principal).Columns("ServicoPrincipalId","OperadoraPrincipalId");
        }
	}
}

