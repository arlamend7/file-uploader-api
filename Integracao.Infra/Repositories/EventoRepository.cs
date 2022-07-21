using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Eventos.Entities;
using System.Data.Common;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class EventoRepository : IRepository
    {
        private readonly SQLiteConnection _connection;

        public EventoRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void Insert(IEnumerable<object> eventos)
        {
            var eventosList = eventos as IEnumerable<Evento>;

            string qry = @"insert into Evento(IdentificadorOperadora,NomePrestador,CnpjPrestador,PrestadorPrincipal,CrmResponsavel,CrmSolicitante,CrmExecutante,ServicoId
                         ,Atendimento, CategoriaAtendimento, DescricaoPosicaoPrestador, ValorApresentado, ValorPago, ValorCoparticipacao, ValorEmpresa, ValorNaoReembolsado
                         ,DataAtendimento,QtdServicoCobrado, QtdServicoPago, DescInternacao, IdentificadorPagamento,OperadoraId,CodigoServicoPrincipal,DescricaoServicoPrincipal
                         ,CodigoServico,DescricaoServico,CodigoBeneficiario) \n VALUES ";

            qry += string.Join(",\n", eventosList.Select(x =>
              $"('{x.IdentificadorExterno}'," +
              $"'{x.NomePrestador}'," +
              $"'{x.CnpjPrestador}'," +
              $"'{x.PrestadorPrincipal}'," +
              $"'{x.CrmResponsavel}'," +
              $"'{x.CrmSolicitante}'," +
              $"'{x.CrmExecutante}'," +
              $"'{x.CodigoServico}'," +
              $"'{x.Atendimento}'," +
              $"'{x.CategoriaAtendimento}'," +
              $"'{x.DescricaoPosicaoPrestador}'," +
              $"'{x.ValorApresentado}'," +
              $"'{x.ValorPago}'," +
              $"'{x.ValorCoparticipacao}'," +
              $"'{x.ValorEmpresa}'," +
              $"'{x.ValorNaoReembolsado}'," +
              $"'{x.DataAtendimento}'," +
              $"'{x.QtdServicoCobrado}'," +
              $"'{x.QtdServicoPago}'," +
              $"'{x.DescInternacao}'," +
              $"'{x.Operadora.Codigo}'," +
              $"'{x.CodigoServicoPrincipal}'," +
              $"'{x.DescricaoServicoPrincipal}'," +
              $"'{x.CodigoServico}'," +
              $"'{x.DescricaoServico}'," +
              $"'{x.CodigoBeneficiario}')"));

            try
            {
                _connection.Open();
                SQLiteCommand command = new SQLiteCommand(qry, _connection);

                var result = command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }
    }
}
