using Integracao.Domain.Base.Repositories;
using Integracao.Domain.Beneficiarios.Entities;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SqlClient;
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
        public void Insert()
        {
            var beneficiariosList = new List<Beneficiario>();

         

            beneficiariosList.Add(new Beneficiario
                (DateTime.Now, Convert.ToChar("M"), "Filho", "Maria", "Caleb", "12345", "03546622014", "1", "TG", "AB"));
            beneficiariosList.Add(new Beneficiario
              (DateTime.Now, Convert.ToChar("M"), "Filho", "Maria", "Nicole", "12345", "03546622014", "1", "TG", "AB"));
            beneficiariosList.Add(new Beneficiario
              (DateTime.Now, Convert.ToChar("M"), "Filho", "Maria", "Arlan", "12345", "03546622014", "1", "TG", "AB"));
            beneficiariosList.Add(new Beneficiario
              (DateTime.Now, Convert.ToChar("M"), "Filho", "Maria", "Perseu", "12345", "03546622014", "1", "TG", "AB"));




            string qry = "insert into Beneficiario(DataNascimento,Sexo,CodigoParentesco,NomeDaMae,Nome,NumeroCNS,CPF,Carteirinha,Empresa,RazaoSocial)\n VALUES ";

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
            $"'{x.RazaoSocial}')"));


            try
            {
                _connection.Open();

                SQLiteCommand command = new SQLiteCommand(qry,_connection);

               var result =  command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception )
            {

                throw new NotImplementedException();
            }




        }
    }
}
