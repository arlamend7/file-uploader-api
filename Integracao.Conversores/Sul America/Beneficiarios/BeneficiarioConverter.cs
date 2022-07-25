using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Interfaces;
using Integracao.Domain.Base.Enumeradores;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Beneficiarios.Enumeradores;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Planos.Entidades;
using Microsoft.VisualBasic.FileIO;

namespace Integracao.Conversores.Sul_America.Beneficiarios
{
    public class BeneficiarioConverter : IOperadoraFileConverter
    {
        public static object locker = new { };
        public IEnumerable<Type> OutTypes => new List<Type>()
            {
                typeof(FileTypeRowConvertResult<Plano>),
                typeof(FileTypeRowConvertResult<Beneficiario>),
                typeof(FileTypeRowConvertResult<BeneficiarioPlano>),
            };

        public FileConverterResult Convert(Stream file, Importacao importacao)
        {
            StreamReader sr = new(file);
            string[] lines = sr.ReadToEnd().Split("\n");

            FileConverterResult result = new();

            result.Rows.AddRange(lines.Skip(1)
                                      .SkipLast(1)
                                      .SelectMany((line, lineIndex) => ConvertLine(lineIndex, line, importacao, result)));

            return result;
        }


        private static IEnumerable<FileTypeRowConvertResult> ConvertLine(int indexLine, string line, Importacao importacao, FileConverterResult result)
        {
            string[] columns = new TextFieldParser(new StringReader(line))
            {
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new string[] { "," }
            }.ReadFields();

            FileTypeRowConvertResult<Plano> plano = new FileColumnsConverter<Plano>(indexLine, columns)
                .Convert(20, x => x.Codigo, long.Parse)
                .Convert(21, x => x.Descricao)
                .SetValue(x => x.Operadora, Operadora.SulAmerica)
                .SetValue(x => x.Importacao, importacao)
                .Result;

            FileTypeRowConvertResult<Beneficiario> beneficiario = new FileColumnsConverter<Beneficiario>(indexLine, columns) //update
                    .Convert(9, x => x.Codigo, long.Parse)
                    .Convert(12, x => x.Nome)
                    .Convert(13, x => x.CPFTitular, long.Parse)
                    .Convert(14, x => x.CPF, long.Parse)
                    .Convert(15, x => x.DataNascimento, DateTime.Parse)
                    .Convert(16, x => x.Sexo, x => x.ToUpper() switch
                    {
                        "M" => SexoEnum.Masculino,
                        "F" => SexoEnum.Feminino,
                        _ => throw new NotImplementedException()
                    })
                    .Convert(17, x => x.Parentesco, x => x switch
                    {
                        "0" => ParentescoEnum.Titular,
                        "1" => ParentescoEnum.Conjuge,
                        "2" => ParentescoEnum.Filhos,
                        "4" => ParentescoEnum.Companheiros,
                        _ => throw new NotImplementedException()
                    })
                    .Convert(19, x => x.NomeDaMae)
                    .Convert(27, x => x.IsDependente, x => x switch
                    {
                        "TITULAR" => SimNaoEnum.Nao,
                        "DEPENDENTE" => SimNaoEnum.Sim,
                        _ => throw new NotImplementedException()
                    })
                    .Convert(29, x => x.Remido, x => x.ToUpper() switch
                    {
                        "NAO" => SimNaoEnum.Nao,
                        "SIM" => SimNaoEnum.Sim,
                        _ => throw new NotImplementedException()
                    })
                    .Convert(34, x => x.NumeroCNS, long.Parse)
                    .SetValue(x => x.Operadora, Operadora.SulAmerica)
                                            .SetValue(x => x.Importacao, importacao)

                    .Result;

            FileTypeRowConvertResult<BeneficiarioPlano> beneficiarioPlano = new FileColumnsConverter<BeneficiarioPlano>(indexLine, columns) //update - acredito que nao tenha update
                 .Convert(0, x => x.NumeroApolice, long.Parse)
                 .Convert(2, x => x.CodigoEmpresa)
                 .Convert(3, x => x.RazaoSocial)
                 .Convert(6, x => x.Cidade)
                 .Convert(7, x => x.UF)
                 .Convert(22, x => x.Acomodacao, x => x switch
                 {
                     "APARTAMENTO" => TipoAcomodacaoEnum.Apartamento,
                     "ENFERMARIA" => TipoAcomodacaoEnum.Enfermaria,
                     _ => throw new NotImplementedException()
                 })
                 .Convert(23, x => x.Inicio, DateTime.Parse)
                 .Convert(24, x => x.Fim, value => DateTime.Parse(value))
                 .Convert(28, x => x.IsDemitidoOuAposentado, x => x switch
                 {
                     "NORMAL" => SimNaoEnum.Nao,
                     "DEMITIDO/APOSENTADO" => SimNaoEnum.Sim,
                     _ => throw new NotImplementedException()
                 })
                 .Convert(30, x => x.DataMaxPermanencia, value => DateTime.Parse(value))
                 .Convert(31, x => x.DataDemissaoOuAposentadoria, value => DateTime.Parse(value))
                 .SetValue(x => x.CodigoPlano, plano.Entity.Codigo)
                 .SetValue(x => x.CodigoBeneficiario, beneficiario.Entity.Codigo)
                                         .SetValue(x => x.Importacao, importacao)
                 .Result;

            List<FileTypeRowConvertResult> lista =  new()
            {
                beneficiario,
                beneficiarioPlano
            };
            
            lock (locker)
            {
                if (!result.Get<Plano>().Any(x => x.Codigo == plano.Entity.Codigo)) lista.Add(plano);
            }

            return lista;

        }
    }
}
