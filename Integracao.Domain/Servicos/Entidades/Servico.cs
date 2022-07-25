using Integracao.Core.Base.Entities;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Servicos.Entidades
{
	public class Servico : EntityBase
	{
        public virtual Operadora Operadora { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Servico Principal { get; set; }
        public virtual Importacao Importacao { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Servico servico &&
              servico.Codigo == this.Codigo && servico.Operadora.Codigo == this.Operadora.Codigo;
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

