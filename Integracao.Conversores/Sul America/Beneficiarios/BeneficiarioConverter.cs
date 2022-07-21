using System.Globalization;
using System.Linq.Expressions;
using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Beneficiarios.Entities;

namespace Integracao.Conversores.Sul_America.Beneficiarios
{
    public class BeneficiarioConverter
    {
        public static FileConverterResult Convert(Stream file)
        {
            StreamReader sr = new StreamReader(file);
            string[] lines = sr.ReadToEnd().Split("\n");

            var result = new FileConverterResult();

            for (int i = 1; i < lines.Count() - 1; i++)
            {
                try
                {
                    result.Sucessos.Add(ConvertLine(lines[i]));
                }
                catch (FileConverterColumnException ex)
                {
                    result.Erros.Add(new FileConverterLineException(i, ex));
                }
            }

            return result;
        }

        private static Beneficiario ConvertLine(string line)
        {
            IEnumerable<string> columns = line.Replace(", 12:00:00 AM", "").Split("," ).Select(x => x.Replace('"', ' ').Replace(@"\", "").Trim());


            return new ColumnsConverter<Beneficiario>(columns)
                        .Convert(2, x => x.Empresa)
                        .Convert(3, x => x.RazaoSocial)
                        .Convert(4, x => x.Produto)
                        .Convert(6, x => x.LocalEmpresa)
                        .Convert(9, x => x.Codigo)
                        .Convert(10, x => x.GrupoFamiliar, long.Parse)
                        .Convert(12, x => x.Nome)
                        .Convert(13, x => x.CPFTitular, long.Parse)
                        .Convert(14, x => x.CPF, long.Parse)
                        .Convert(15, x => x.DataNascimento, value => DateTime.Parse(value, CultureInfo.GetCultureInfo("en-US")))
                        .Convert(16, x => x.Sexo)
                        .Convert(17, x => x.CodigoParentesco)
                        .Convert(18, x => x.DescricaoParentesco)
                        .Convert(19, x => x.NomeDaMae)
                        .Convert(20, x => x.CodigoPlano)
                        .Convert(21, x => x.DescricaoPlano)
                        .Convert(22, x => x.Acomodacao)
                        .Convert(23, x => x.InicioPlano, value => DateTime.Parse(value, CultureInfo.GetCultureInfo("en-US")))
                        .Convert(24, x => x.FimPlano, value => DateTime.Parse(value, CultureInfo.GetCultureInfo("en-US")))
                        .Convert(25, x => x.CodigoPermanencia)
                        .Convert(26, x => x.DescricaoPermanencia)
                        .Convert(27, x => x.TipoBeneficiario)
                        .Convert(28, x => x.TipoSegurado)
                        .Convert(29, x => x.Remido)
                        .Convert(30, x => x.DataMaxPermanencia, value => DateTime.Parse(value, CultureInfo.GetCultureInfo("en-US")))
                        .Convert(31, x => x.DataDemissaoOuAposentadoria, value => DateTime.Parse(value, CultureInfo.GetCultureInfo("en-US")))
                        .Convert(32, x => x.CodigoSetor, long.Parse)
                        .Convert(33, x => x.DescricaoSetor)
                        .Convert(34, x => x.NumeroCNS, long.Parse)
                        .Result;
        }

       
    }
}
