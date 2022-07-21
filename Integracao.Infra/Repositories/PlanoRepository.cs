using Integracao.Domain.Planos.Entidades;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class PlanoRepository
    {
        private readonly SQLiteConnection _connection;
        public PlanoRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Insert(IEnumerable<object> planos)
        {
            string qry = "insert into Plano(Descricao,OperadoraId,PlanoId)\n VALUES ";
            var planosList = planos as IEnumerable<Plano>;

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
