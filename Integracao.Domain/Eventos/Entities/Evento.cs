using Integracao.Domain.Eventos.Enums;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Eventos.Entities
{
    public class Evento : EntityBase
    {
        public virtual string IdentificadorExterno { get; set; }
        public virtual string NomePrestador { get; set; }
        public virtual string CnpjPrestador { get; set; }
        public virtual string PrestadorPrincipal { get; set; }
        public virtual string CrmResponsavel { get; set; }
        public virtual string CrmSolicitante { get; set; }
        public virtual string CrmExecutante { get; set; }
        public virtual AtendimentoEnum? Atendimento { get; set; }
        public virtual string CategoriaAtendimento { get; set; }
        public virtual string DescricaoPosicaoPrestador { get; set; }
        public virtual decimal? ValorApresentado { get; set; }
        public virtual decimal? ValorPago { get; set; }
        public virtual decimal? ValorCoparticipacao { get; set; }
        public virtual decimal? ValorEmpresa { get; set; }
        public virtual decimal? ValorNaoReembolsado { get; set; }
        public virtual DateTime? DataAtendimento { get; set; }
        public virtual DateTime? DataInternacao { get; set; }
        public virtual int? QtdServicoCobrado { get; set; }
        public virtual int? QtdServicoPago { get; set; }
        public virtual string DescInternacao { get; set; }
        public virtual string IdentificadorPagamento { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual string CodigoServicoPrincipal { get; set; }
        public virtual string DescricaoServicoPrincipal { get; set; }
        public virtual string CodigoServico { get; set; }
        public virtual string DescricaoServico { get; set; }
        public virtual string CodigoBeneficiario { get; set; }

        public Evento()
        {

        }
    }
}
