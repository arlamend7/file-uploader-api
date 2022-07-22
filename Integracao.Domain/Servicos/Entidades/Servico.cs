using System;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Planos.Entidades;

namespace Integracao.Domain.Servicos.Entidades
{
	public class Servico : EntityBase
	{
        public virtual Operadora Operadora { get; set; }
        public virtual string Descricao { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Servico servico &&
              servico.Codigo == this.Codigo && servico.Operadora.Codigo == this.Operadora.Codigo;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

