using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Apolices.Entities
{
    public class Apolice : EntityBase
    {
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

        protected Apolice()
        {

        }

        public Apolice(string codigo, string localEmpresa, string produto, string plano, string setor, DateTime? dataMaxPermanencia, DateTime? dataInativo, string remido, string tipoBeneficiario, string tipoSegurado, DateTime? permanencia, DateTime? inicioPlano, DateTime? fimPlano, string acomodacao)
        {
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
