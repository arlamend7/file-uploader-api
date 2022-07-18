﻿using Integracao.Domain.Eventos.Enums;
using Integracao.Domain.Servicos.Entities;
using Integracao.Core.Base.Entities;

namespace Integracao.Domain.Eventos.Entities
{
    public class Evento : EntityBase
    {
        public virtual string IdentificadorOperadora { get; set; }
        public virtual string NomePrestador { get; set; }
        public virtual string CnpjPrestador { get; set; }
        public virtual string PrestadorPrincipal { get; set; }
        public virtual string CrmResponsavel { get; set; }
        public virtual string CrmSolicitante { get; set; }
        public virtual string CrmExecutante { get; set; }
        public virtual Servico Servico { get; set; }
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

        protected Evento()
        {

        }

        public Evento(string identificadorOperadora, string nomePrestador, string cnpjPrestador, string prestadorPrincipal, string crmResponsavel, string crmSolicitante, string crmExecutante, Servico servico, AtendimentoEnum atendimento, string categoriaAtendimento, string descricaoPosicaoPrestador, decimal? valorApresentado, decimal? valorPago, decimal? valorCoparticipacao, decimal? valorEmpresa, decimal? valorNaoReembolsado, DateTime? dataAtendimento, DateTime? dataInternacao, int? qtdServicoCobrado, int? qtdServicoPago, string descInternacao, string identificadorPagamento)
        {
            IdentificadorOperadora = identificadorOperadora;
            NomePrestador = nomePrestador;
            CnpjPrestador = cnpjPrestador;
            PrestadorPrincipal = prestadorPrincipal;
            CrmResponsavel = crmResponsavel;
            CrmSolicitante = crmSolicitante;
            CrmExecutante = crmExecutante;
            Servico = servico;
            Atendimento = atendimento;
            CategoriaAtendimento = categoriaAtendimento;
            DescricaoPosicaoPrestador = descricaoPosicaoPrestador;
            ValorApresentado = valorApresentado;
            ValorPago = valorPago;
            ValorCoparticipacao = valorCoparticipacao;
            ValorEmpresa = valorEmpresa;
            ValorNaoReembolsado = valorNaoReembolsado;
            DataAtendimento = dataAtendimento;
            DataInternacao = dataInternacao;
            QtdServicoCobrado = qtdServicoCobrado;
            QtdServicoPago = qtdServicoPago;
            DescInternacao = descInternacao;
            IdentificadorPagamento = identificadorPagamento;
        }
    }
}