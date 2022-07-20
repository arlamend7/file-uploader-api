using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Operadoras.Entities;
using System.Data.SqlClient;

namespace Integracao.Infra.Repositories
{
    public class OperadoraRepository : IRepository
    {
        public void Insert(IEnumerable<object> operadoras)
        {
            var operadorasList = operadoras as IEnumerable<Operadora>;

            var qry = "";

            using (SqlConnection conn = new SqlConnection("connectionString"))
            {
                SqlCommand sqlCommand = new SqlCommand(qry, conn);

                try   
                {

                }
                catch (Exception)
                {

                    throw new NotImplementedException();

                }

            }
        }
    }
}
