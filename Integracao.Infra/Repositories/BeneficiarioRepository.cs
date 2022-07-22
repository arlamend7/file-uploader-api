using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Operadoras.Enums;
using System.Data;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class BeneficiarioRepository : IRepository
    {
        private readonly SQLiteConnection _connection;
        private readonly IQueryRepository _queryRepository;

        public BeneficiarioRepository(SQLiteConnection connection, IQueryRepository queryRepository)
        {
            _connection = connection;
            _queryRepository = queryRepository;
        }
        public void Insert(IEnumerable<object> beneficiarios, OperadoraEnum operadora)
        {
            var query = _queryRepository.Query<Beneficiario>()
                                  .Where(x => x.Operadora.Codigo == (int)operadora);

            var beneficiariosList = beneficiarios.Select(x => x as Beneficiario).Except(query);
            if (!beneficiariosList.Any()) return;

            string qry = @"insert into Beneficiario(DataNascimento,Sexo,Parentesco,NomeDaMae,Nome,NumeroCNS,CPF,Codigo,Remido,IsDependente,CPFTitular)\n VALUES ";

            qry += string.Join(",\n", beneficiariosList.Select(x =>
            $"('{x.DataNascimento.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{(char)x.Sexo}'," +
            $"'{(int)x.Parentesco}'," +
            $"'{x.NomeDaMae}'," +
            $"'{x.Nome}'," +
            $"'{x.NumeroCNS}'," +
            $"'{x.CPF}'," +
            $"'{x.Codigo}'," +
            $"'{(char)x.Remido}'," +
            $"'{(char)x.IsDependente}'," +
            $"'{x.CPFTitular}')"));

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
