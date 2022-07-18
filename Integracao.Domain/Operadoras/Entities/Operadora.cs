using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Operadoras.Entities
{
    public class Operadora : EntityBase
    {
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }

        protected Operadora()
        {

        }

        public Operadora(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}
