using System;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Servicos.Entidades
{
	public class Servico : EntityBase
	{
        public virtual string Descricao { get; set; }
        public virtual Servico Principal { get; set; }
        public virtual Operadora Operadora { get; set; }
    }
}

