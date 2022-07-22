using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Operadoras.Enums;
using Integracao.Domain.Planos.Entidades;
using Integracao.Infra.Extensions;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class PlanoRepository : IRepository
    {
        private readonly SQLiteConnection _connection;
        private readonly IQueryRepository _queryRepository;

        public PlanoRepository(SQLiteConnection connection, IQueryRepository queryRepository)
        {
            _connection = connection;
            _queryRepository = queryRepository;
        }
        public void Insert(IEnumerable<object> planos, OperadoraEnum operadora)
        {
            string qry = "insert into Plano(Descricao,OperadoraId,PlanoId)\n VALUES ";

            var queryPlanos = _queryRepository.Query<Plano>()
                                              .Where(x => x.Operadora.Codigo == (int)operadora);

            var planosList = planos.Select(x => x as Plano)
                                   .Except(queryPlanos);

            if (!planosList.Any()) return;

            qry += string.Join(",\n", planosList.Select(x =>
                 $"('{x.Operadora.Codigo}'," +
                 $"'{x.Descricao}'," +
                 $"'{x.Codigo}')"));

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
