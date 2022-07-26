using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Eventos.Entities;
using Integracao.Domain.Operadoras.Enums;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class EventoRepository : IRepository
    {
        private readonly SQLiteConnection _connection;
        private readonly IQueryRepository _queryRepository;

        public EventoRepository(SQLiteConnection connection, IQueryRepository queryRepository)
        {
            _connection = connection;
            _queryRepository = queryRepository;
        }

        public void Insert(IEnumerable<object> eventos, OperadoraEnum operadora)
        {

            var eventosList = eventos.Select(x => x as Evento);

            string qry = @"insert into Evento(NomePrestador,CNPJPrestador,CNJPrestadorPrincipal,CrmResponsavel,CrmSolicitante,CrmExecutante,Atendimento,CategoriaAtendimento,
                           PosicaoPrestador,ValorApresentado,ValorPago,ValorCoparticipacao,ValorEmpresa,ValorNaoReembolsado,
                           DataAtendimento,DataInternacao,QtdServicoCobrado,QtdServicoPago,DescInternacao,IdentificadorPagamento,
                            BeneficiarioId,PlanoId,CodigoDocumento,CodigoGrupoEstatico,NumeroLote,NumeroGuia,TipoGuia,ServicoId,OperadoraId)\n VALUES ";

            qry += string.Join(",\n", eventosList.Select(x => 
            $"('{x.NomePrestador}'," +
            $"'{x.CNPJPrestador}'," +
            $"'{x.CrmResponsavel}'," +
            $"'{x.CrmSolicitante}'," +
            $"'{x.CrmExecutante}'," +
            $"'{x.Atendimento}'," +
            $"'{x.CategoriaAtendimento}'," +
            $"'{x.PosicaoPrestador}'," +
            $"'{x.ValorApresentado}'," +
            $"'{x.ValorPago}'," +
            $"'{x.ValorCoparticipacao}'," +
            $"'{x.ValorEmpresa}'," +
            $"'{x.ValorNaoReembolsado}'," +
            $"'{x.DataAtendimento:yyyy-MM-dd HH:mm:ssss}'," +
            $"'{x.DataInternacao?.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.QtdServicoCobrado}'," +
            $"'{x.QtdServicoPago}'," +
            $"'{x.DescInternacao}'," +
            $"'{x.IdentificadorPagamento}'," +
            $"'{x.CodigoBeneficiario}'," +
            $"'{x.CodigoPlano}'," +
            $"'{x.CodigoDocumento}'," +
            $"'{x.CodigoGrupoEstatico}'," +
            $"'{x.NumeroLote}'," +
            $"'{x.TipoGuia}'," +
            $"'{x.Servico.Codigo}'," +
            $"'{x.Servico.Operadora.Codigo}')"));

             _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {
                SQLiteCommand command = new SQLiteCommand(qry, _connection);

                var result = command.ExecuteNonQuery();
                transaction.Commit();
                _connection.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
                _connection.Close();
                throw;
            }

        }
    }
}
