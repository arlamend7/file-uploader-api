using System.Globalization;
using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Exceptions;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Base.Enumeradores;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Beneficiarios.Enumeradores;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Planos.Entidades;
using Microsoft.VisualBasic.FileIO;

namespace Integracao.Conversores.Sul_America.Beneficiarios
{
    public class BeneficiarioConverter
    {
        private static readonly List<Type> types = new()
            {
                typeof(Plano),
                typeof(Beneficiario),
                typeof(BeneficiarioPlano),
            };

        public static FileConverterResult Convert(Stream file, out IEnumerable<Type> types)
        {
            types = BeneficiarioConverter.types;
            StreamReader sr = new(file);
            string[] lines = sr.ReadToEnd().Split("\n");

            FileConverterResult result = new();

            for (int i = 1; i < lines.Length - 1; i++)
            {
                try
                {
                    result.Sucessos.AddRange(ConvertLine(lines[i], result.Get<Plano>()));
                }
                catch (FileConverterColumnException ex)
                {
                    result.Erros.Add(new FileConverterLineException(i, ex));
                }
            }

            return result;
        }

        private static IEnumerable<EntityBase> ConvertLine(string line, IEnumerable<Plano> planos)
        {
            TextFieldParser parser = new(new StringReader(line));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            var columns = parser.ReadFields();

            Plano plano = new ColumnsConverter<Plano>(columns) //insert
                    .Convert(20, x => x.Codigo, long.Parse)
                    .Convert(21, x => x.Descricao)
                    .SetValue(x => x.Operadora, Operadora.SulAmerica)
                    .Result;

            Beneficiario beneficiario =  new ColumnsConverter<Beneficiario>(columns) //update
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
                        .Result;

            BeneficiarioPlano beneficiarioPlano = new ColumnsConverter<BeneficiarioPlano>(columns) //update - acredito que nao tenha update
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
                    .Convert(23, x => x.Inicio,DateTime.Parse)
                    .Convert(24, x => x.Fim, value => DateTime.Parse(value))
                    .Convert(28, x => x.IsDemitidoOuAposentado, x => x switch
                    {
                        "NORMAL" => SimNaoEnum.Nao,
                        "DEMITIDO/APOSENTADO" => SimNaoEnum.Sim,
                        _ => throw new NotImplementedException()
                    })
                    .Convert(30, x => x.DataMaxPermanencia, value => DateTime.Parse(value))
                    .Convert(31, x => x.DataDemissaoOuAposentadoria, value => DateTime.Parse(value))
                    .SetValue(x => x.CodigoPlano, plano.Codigo)
                    .SetValue(x => x.CodigoBeneficiario, beneficiario.Codigo)
                    .Result;

            List<EntityBase> lista =  new()
            {
                beneficiario,
                beneficiarioPlano
            };

            if (!planos.Any(x => x.Codigo == plano.Codigo)) lista.Add(plano);

            return lista;

        }

       
    }
}
