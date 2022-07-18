using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Core.Base.Entities;
namespace Integracao.Domain.BeneficiariosFamiliares.Entities
{
    public class BeneficiarioFamiliar : EntityBase
    {
        public virtual Beneficiario Beneficiario { get; set; }
        public virtual Beneficiario Titular { get; set; }
        public virtual string CodigoParentesco { get; set; }
        public virtual string GrupoFamiliar { get; set; }

        protected BeneficiarioFamiliar()
        {

        }

        public BeneficiarioFamiliar(Beneficiario beneficiario, Beneficiario titular, string codigoParentesco, string grupoFamiliar)
        {
            Beneficiario = beneficiario;
            Titular = titular;
            CodigoParentesco = codigoParentesco;
            GrupoFamiliar = grupoFamiliar;
        }
    }
}
