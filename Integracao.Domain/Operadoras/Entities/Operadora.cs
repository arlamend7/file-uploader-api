using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Operadoras.Entities
{
    public class Operadora : EntityBase
    {
        public virtual string Descricao { get; set; }

        protected Operadora()
        {

        }

        public Operadora(long codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return Descricao;
        }
        public static Operadora SulAmerica = new SulAmericaOperadora();

        private class SulAmericaOperadora : Operadora
        {
            public SulAmericaOperadora() : base(1, "SulAmerica")
            {

            }
        }
    }
}
