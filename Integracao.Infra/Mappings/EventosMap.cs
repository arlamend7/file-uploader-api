using FluentNHibernate.Mapping;
using Integracao.Domain.Eventos.Entities;

namespace Integracao.Infra.Mappings
{
    public class EventosMap : ClassMap<Evento>
    {
        public EventosMap() 
        {
            Table("Evento");
            Id(x => x.Codigo).Column("EventoId");
            Map(x => x.NomePrestador);
            Map(x => x.CNPJPrestador);
            Map(x => x.CNPJPrestadorPrincipal);
            Map(x => x.CrmResponsavel);
            Map(x => x.CrmSolicitante);
            Map(x => x.CrmExecutante);
            Map(x => x.Atendimento);
            Map(x => x.CategoriaAtendimento);
            Map(x => x.PosicaoPrestador);
            Map(x=>x.ValorApresentado);
            Map(x => x.ValorPago);
            Map(x => x.ValorCoparticipacao);
            Map(x => x.ValorEmpresa);
            Map(x=>x.ValorNaoReembolsado);
            Map(x => x.DataAtendimento);
            Map(x => x.DataInternacao);
            Map(x => x.QtdServicoCobrado);
            Map(x => x.QtdServicoPago);
            Map(x => x.DescInternacao);
            Map(x => x.IdentificadorPagamento);
            Map(x => x.CodigoBeneficiario).Column("BeneficiarioId");
            Map(x => x.CodigoPlano).Column("PlanoId");
            Map(x => x.CodigoDocumento);
            Map(x => x.CodigoGrupoEstatico);
            Map(x => x.NumeroLote);
            Map(x => x.NumeroGuia);
            Map(x => x.TipoGuia);
            

            //References(x => x.Servico).Column("ServicoId");
            References(x => x.Operadora).Column("OperadoraId");

            

        }
    }
}
