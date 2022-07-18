﻿using FluentNHibernate.Mapping;
using Integracao.Domain.Eventos.Entities;

namespace Integracao.Infra.Mappings
{
    public class EventosMap : ClassMap<Evento>
    {
        public EventosMap()
        {
            Table("Eventos");
            Id(x => x.Id).Column("EventoId");
            Map(x => x.IdentificadorOperadora);
            Map(x => x.NomePrestador);
            Map(x => x.CnpjPrestador);
            Map(x => x.PrestadorPrincipal);
            Map(x => x.CrmResponsavel);
            Map(x => x.CrmSolicitante);
            Map(x => x.CrmExecutante);
            References(x => x.Servico).Column("ServicoId");
            Map(x => x.Atendimento);
            Map(x => x.CategoriaAtendimento);
            Map(x => x.DescricaoPosicaoPrestador);
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

        }
    }
}