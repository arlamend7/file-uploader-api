using System;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Planos.Entidades
{
	public class Plano : EntityBase
	{
        public Operadora Operadora { get; set; }
        public string Descricao { get; set; }
    }
}

