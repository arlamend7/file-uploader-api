using Integracao.Domain.Beneficiarios.Entities;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class BeneficiarioPlanoRepository
    {
        private readonly SQLiteConnection _connection;
        public BeneficiarioPlanoRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void Insert(IEnumerable<object> beneficiarioPlanos)
        {
            var beneficiariosPlanoList = beneficiarioPlanos as IEnumerable<BeneficiarioPlano>;

            var qry = @"insert into BeneficiarioPlano(NumeroApolice,UF,Cidade,Inicio,Fim,DataMaxPermanencia,DataDemissaoOuAposentadoria
                               Acomodacao,IsDemitidoOuAposentado,BeneficiarioId,PlanoId,RazaoSocial,CodigoEmpresa)";

            qry += String.Join("\n", beneficiariosPlanoList.Select(x =>
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
