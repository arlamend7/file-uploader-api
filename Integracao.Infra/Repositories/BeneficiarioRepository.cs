using Integracao.Domain.Beneficiarios.Entities;
using System.Data;
using System.Data.SQLite;

namespace Integracao.Infra.Repositories
{
    public class BeneficiarioRepository
    {
        private readonly SQLiteConnection _connection;

        public BeneficiarioRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }
        public void Insert(IEnumerable<object> beneficiarios)
        {
            var beneficiariosList = beneficiarios as IEnumerable<Beneficiario>;

            string qry = @"insert into Beneficiario(DataNascimento,Sexo,CodigoParentesco,
                           NomeDaMae,Nome,NumeroCNS,CPF,Carteirinha
                           ,Empresa,RazaoSocial,Codigo,LocalEmpresa
                           ,Produto,Plano,Setor,DataMaxPermanencia,DataInativo,Remido,
                           TipoBeneficiario,TipoSegurado,Permanencia,InicioPlano,FimPlano,
                           Acomodacao,GrupoFamiliar)\n VALUES ";

            qry += string.Join(",\n", beneficiariosList.Select(x =>
            $"('{x.DataNascimento.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.Sexo}'," +
            $"'{(int)x.Parentesco}'," +
            $"'{x.NomeDaMae}'," +
            $"'{x.Nome}'," +
            $"'{x.NumeroCNS}'," +
            $"'{x.CPF}'," +
            $"'{x.Codigo}'," +
            $"'{x.Remido}'," +
            $"'{(char)x.IsDependente}'"));


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
