using Integracao.Core.Base.Entities;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Planos.Entidades
{
    public class Plano : EntityBase
	{
        public virtual Operadora Operadora { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Importacao Importacao { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Plano plano &&
              plano.Codigo == this.Codigo && plano.Operadora.Codigo == this.Operadora.Codigo;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return Descricao;
        }
    }
}

