using Integracao.Core.Base.Entities;
using Integracao.Domain.Base.Enumeradores;
using Integracao.Domain.Beneficiarios.Enumeradores;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Beneficiarios.Entities
{
    public class Beneficiario : EntityBase
    {
        public virtual string NomeDaMae { get; set; }
        public virtual string Nome { get; set; }
        public virtual long NumeroCNS { get; set; }
        public virtual long CPF { get; set; }
        public virtual long CPFTitular { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual SexoEnum Sexo { get; set; }
        public virtual ParentescoEnum Parentesco { get; set; }
        public virtual SimNaoEnum Remido { get; set; }
        public virtual SimNaoEnum IsDependente { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual Importacao Importacao { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Beneficiario beneficiario &&
                beneficiario.Codigo == this.Codigo && beneficiario.Operadora.Codigo == this.Operadora.Codigo;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Codigo.ToString();
        }
    }

 
}
