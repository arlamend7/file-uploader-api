using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;

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
        public virtual string Codigo { get; set; }
        public virtual string LocalEmpresa { get; set; }
        public virtual string Produto { get; set; }
        public virtual string Plano { get; set; }
        public virtual string Setor { get; set; }
        public virtual DateTime? DataMaxPermanencia { get; set; }
        public virtual DateTime? DataInativo { get; set; }
        public virtual string Remido { get; set; }
        public virtual string TipoBeneficiario { get; set; }
        public virtual string TipoSegurado { get; set; }
        public virtual DateTime? Permanencia { get; set; }
        public virtual DateTime? InicioPlano { get; set; }
        public virtual DateTime? FimPlano { get; set; }
        public virtual string Acomodacao { get; set; }
        public virtual string GrupoFamiliar { get; set; }
        public virtual Operadora Operadora { get; set; }
        protected Beneficiario()
        {

        }

        public Beneficiario(DateTime? dataNascimento, char sexo, string codigoParentesco, string nomeDaMae, string nome, string numeroCNS, string cPF, string carteirinha, string empresa, string razaoSocial, string codigo, string localEmpresa, string produto, string plano, string setor, DateTime? dataMaxPermanencia, DateTime? dataInativo, string remido, string tipoBeneficiario, string tipoSegurado, DateTime? permanencia, DateTime? inicioPlano, DateTime? fimPlano, string acomodacao)
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
            Codigo = codigo;
            LocalEmpresa = localEmpresa;
            Produto = produto;
            Plano = plano;
            Setor = setor;
            DataMaxPermanencia = dataMaxPermanencia;
            DataInativo = dataInativo;
            Remido = remido;
            TipoBeneficiario = tipoBeneficiario;
            TipoSegurado = tipoSegurado;
            Permanencia = permanencia;
            InicioPlano = inicioPlano;
            FimPlano = fimPlano;
            Acomodacao = acomodacao;
        }
    }
}
