using Integracao.Core.Base.Entities;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Servicos.Entidades;

namespace Integracao.Domain.Eventos.Entities
{
    public class Evento : EntityBase
    {
        public virtual long CodigoBeneficiario { get; set; }
        public virtual long CodigoPlano { get; set; }
        public virtual Operadora Operadora { get; set; }
        public virtual Servico Servico { get; set; }
        public virtual string NomePrestador { get; set; }
        public virtual long CNPJPrestador { get; set; }
        public virtual long? CNPJPrestadorPrincipal { get; set; }
        public virtual long? CrmResponsavel { get; set; }
        public virtual long? CrmSolicitante { get; set; }
        public virtual long? CrmExecutante { get; set; }
        public virtual long CodigoGrupoEstatico { get; set; }
        public virtual string Atendimento { get; set; }
        public virtual string CategoriaAtendimento { get; set; }
        public virtual string PosicaoPrestador { get; set; }
        public virtual decimal ValorApresentado { get; set; }
        public virtual decimal ValorPago { get; set; }
        public virtual decimal ValorCoparticipacao { get; set; }
        public virtual decimal ValorEmpresa { get; set; }
        public virtual decimal ValorNaoReembolsado { get; set; }
        public virtual DateTime DataAtendimento { get; set; }
        public virtual DateTime? DataInternacao { get; set; }
        public virtual int QtdServicoCobrado { get; set; }
        public virtual int QtdServicoPago { get; set; }
        public virtual string DescInternacao { get; set; }
        public virtual string IdentificadorPagamento { get; set; }
        public virtual long CodigoDocumento { get; set; }
        public virtual long? NumeroLote { get; set; }
        public virtual long NumeroGuia { get; set; }
        public virtual char? TipoGuia { get; set; }

        public Evento()
        {

        }
    }
}
