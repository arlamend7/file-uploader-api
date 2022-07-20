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
            $"('{x.DataNascimento.Value.ToString("yyyy-MM-dd HH:mm:ssss")}'," +
            $"'{x.Sexo}'," +
            $"'{x.CodigoParentesco}'," +
            $"'{x.NomeDaMae}'," +
            $"'{x.Nome}'," +
            $"'{x.NumeroCNS}'," +
            $"'{x.CPF}'," +
            $"'{x.Carteirinha}'," +
            $"'{x.Empresa}'," +
            $"'{x.RazaoSocial}'," +
            $"'{x.Codigo}'," +
            $"'{x.LocalEmpresa}'," +
            $"'{x.Produto}'," +
            $"'{x.Plano}'," +
            $"'{x.Setor}'," +
            $"'{x.DataMaxPermanencia}'," +
            $"'{x.DataInativo}'," +
            $"'{x.Remido}'," +
            $"'{x.TipoBeneficiario}'," +
            $"'{x.TipoSegurado}'," +
            $"'{x.Permanencia}'," +
            $"'{x.InicioPlano}'," +
            $"'{x.FimPlano}'," +
            $"'{x.Acomodacao}'," +
            $"'{x.GrupoFamiliar}'," +
            $"'{x.LocalEmpresa}')"));


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
