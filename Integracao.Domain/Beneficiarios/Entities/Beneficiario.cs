using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Beneficiarios.Entities
{
    public class Beneficiario : EntityBase
    {
        public virtual DateTime DataNascimento { get; set; }
        public virtual char Sexo { get; set; }
        public virtual string CodigoParentesco { get; set; }
        public virtual string DescricaoParentesco { get; set; }
        public virtual string NomeDaMae { get; set; }
        public virtual string Nome { get; set; }
        public virtual long NumeroCNS { get; set; }
        public virtual long CPF { get; set; }
        public virtual long CPFTitular { get; set; }
        public virtual string NomeTitular { get; set; }
        public virtual string Carteirinha { get; set; }
        public virtual string Empresa { get; set; }
        public virtual string RazaoSocial { get; set; }
        public virtual string Codigo { get; set; }
        public virtual string LocalEmpresa { get; set; }
        public virtual string Produto { get; set; }
        public virtual string CodigoPlano { get; set; }
        public virtual string DescricaoPlano { get; set; }
        public virtual long CodigoSetor { get; set; }
        public virtual string DescricaoSetor { get; set; }
        public virtual DateTime? DataMaxPermanencia { get; set; }
        public virtual DateTime? DataDemissaoOuAposentadoria { get; set; }
        public virtual DateTime? DataInativo { get; set; }
        public virtual string Remido { get; set; }
        public virtual string TipoBeneficiario { get; set; }
        public virtual string TipoSegurado { get; set; }
        public virtual string CodigoPermanencia { get; set; }
        public virtual string DescricaoPermanencia { get; set; }
        public virtual DateTime InicioPlano { get; set; }
        public virtual DateTime? FimPlano { get; set; }
        public virtual string Acomodacao { get; set; }
        public virtual long GrupoFamiliar { get; set; }
        public virtual Operadora Operadora { get; set; }

        public Beneficiario()
        {

        }
    }
}
