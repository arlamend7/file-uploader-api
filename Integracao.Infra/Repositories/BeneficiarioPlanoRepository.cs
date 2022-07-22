using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Operadoras.Enums;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class BeneficiarioPlanoRepository : IRepository
    {
        private readonly SQLiteConnection _connection;
        private readonly IQueryRepository _queryRepository;

        public BeneficiarioPlanoRepository(SQLiteConnection connection, IQueryRepository queryRepository)
        {
            _connection = connection;
            _queryRepository = queryRepository;
        }

        public void Insert(IEnumerable<object> beneficiarioPlanos, OperadoraEnum operadora)
        {
            var query = _queryRepository.Query<BeneficiarioPlano>()
                                        .Where(x => x.Operadora.Codigo == (int)operadora);
            var beneficiariosPlanoList = beneficiarioPlanos.Select(x => x as BeneficiarioPlano).Except(query);
            if (!beneficiariosPlanoList.Any()) return;

            var qry = @"insert into BeneficiarioPlano(NumeroApolice,UF,Cidade,Inicio,Fim,DataMaxPermanencia,DataDemissaoOuAposentadoria
                               Acomodacao,IsDemitidoOuAposentado,BeneficiarioId,PlanoId,RazaoSocial,CodigoEmpresa)";

            qry += string.Join("\n", beneficiariosPlanoList.Select(x =>
            $"('{x.NumeroApolice}'," +
            $"'{x.UF}'," +
            $"'{x.Cidade}'," +
            $"'{x.Inicio.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.Fim?.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.DataMaxPermanencia?.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.DataDemissaoOuAposentadoria?.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.Acomodacao}'," +
            $"'{(char)x.IsDemitidoOuAposentado}'," +
            $"'{x.CodigoBeneficiario}'," +
            $"'{x.CodigoPlano}'," +
            $"'{x.RazaoSocial}'," +
            $"'{x.CodigoEmpresa}')"));

            _connection.Open();
            var transaction = _connection.BeginTransaction();
            try
            {

                SQLiteCommand command = new SQLiteCommand(qry, _connection);

                command.ExecuteNonQuery();
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
