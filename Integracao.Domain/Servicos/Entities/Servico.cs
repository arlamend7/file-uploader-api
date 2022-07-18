using Integracao.Domain.Operadoras.Entities;
using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Servicos.Entities
{
   public class Servico : EntityBase
    {
        public virtual Operadora Operadora { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Servico Principal { get; set; }

        protected Servico()
        {

        }

        public Servico(Operadora operadora, string codigo, string desricao, Servico principal)
        {
            Operadora = operadora;
            Codigo = codigo;
            Descricao = desricao;
            Principal = principal;
        }
    }
}
