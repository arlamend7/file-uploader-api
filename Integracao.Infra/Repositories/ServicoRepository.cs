using Integracao.Domain.Planos.Entidades;
using Integracao.Domain.Servicos.Entidades;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class ServicoRepository
    {
        private readonly SQLiteConnection _connection;
        public ServicoRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Insert(IEnumerable<object> planos)
        {
            string qry = "insert into Plano(Descricao,OperadoraId,ServicoId)\n VALUES ";
            var servicosList = planos as IEnumerable<Servico>;

            qry += string.Join(",\n", servicosList.Select(x =>
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
