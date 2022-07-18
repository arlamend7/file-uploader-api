using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Beneficiarios.Entities
{
    public class Beneficiario : EntityBase
    {
        public virtual DateTime? DataNascimento { get; set; }
        public virtual char Sexo { get; set; }
        public virtual string CodigoParentesco { get; set; }
        public virtual string NomeDaMae { get; set; }
        public virtual string Nome { get; set; }
        public virtual string NumeroCNS { get; set; }
        public virtual string CPF { get; set; }
        public virtual string Carteirinha { get; set; }
        public virtual string Empresa { get; set; }
        public virtual string RazaoSocial { get; set; }
     
        protected Beneficiario()
        {

        }

        public Beneficiario(DateTime? dataNascimento, char sexo, string codigoParentesco, string nomeDaMae, string nome, string numeroCNS, string cPF, string carteirinha, string empresa, string razaoSocial)
        {
            DataNascimento = dataNascimento;
            Sexo = sexo;
            CodigoParentesco = codigoParentesco;
            NomeDaMae = nomeDaMae;
            Nome = nome;
            NumeroCNS = numeroCNS;
            CPF = cPF;
            Carteirinha = carteirinha;
            Empresa = empresa;
            RazaoSocial = razaoSocial;
        }
    }
}
