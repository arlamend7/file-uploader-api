using Integracao.Domain.Base.Repositories;
using Integracao.Domain.BeneficiariosFamiliares.Entities;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;


namespace Integracao.Infra.Repositories
{
    public class BeneficiarioFamiliarRepository : IRepository
    {
        private readonly SqliteConnection _sqlConnection;
        public BeneficiarioFamiliarRepository(SqliteConnection  sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public void Insert(IEnumerable<object> beneficiariosFamiliares)
        {
            var beneficiariosFamiliaresList = beneficiariosFamiliares as IEnumerable<BeneficiarioFamiliar>;
        



        }
    }
}
