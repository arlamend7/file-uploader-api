using System;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Base.Enumeradores;
using Integracao.Domain.Beneficiarios.Enumeradores;
using Integracao.Domain.Planos.Entidades;

namespace Integracao.Domain.Beneficiarios.Entities
{
	public class BeneficiarioPlano : EntityBase
	{
        public virtual long NumeroApolice { get; set; }
        public virtual string UF { get; set; }
        public virtual string Cidade { get; set; }
        public virtual DateTime Inicio { get; set; }
        public virtual DateTime? Fim { get; set; }
        public virtual DateTime? DataMaxPermanencia { get; set; }
        public virtual DateTime? DataDemissaoOuAposentadoria { get; set; }
        public virtual TipoAcomodacaoEnum Acomodacao { get; set; }
        public virtual SimNaoEnum IsDemitidoOuAposentado { get; set; }
        public virtual Beneficiario Beneficiario { get; set; }
        public virtual Plano Plano { get; set; }
    }
}

