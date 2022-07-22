using System.Globalization;
using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Exceptions;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Beneficiarios.Entities;
using Integracao.Domain.Eventos.Entities;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Planos.Entidades;
using Integracao.Domain.Servicos.Entidades;
using Microsoft.VisualBasic.FileIO;

namespace Integracao.Conversores.Sul_America.Eventos
{
    public class EventoConverter
    {
        private static readonly List<Type> types = new List<Type>()
            {
                typeof(Evento),
                typeof(Servico)
            };

        public static FileConverterResult Convert(Stream file, out IEnumerable<Type> types)
        {
            types = EventoConverter.types;

            StreamReader sr = new(file);
            string[] lines = sr.ReadToEnd().Split("\n");

            FileConverterResult result = new();

            for (int i = 1; i < lines.Length - 1; i++)
            {
                try
                {
                    if (i == 230) i = 230;
                    result.Sucessos.AddRange(ConvertLine(lines[i], result));
                }
                catch (FileConverterColumnException ex)
                {
                    result.Erros.Add(new FileConverterLineException(i, ex));
                }
            }

            return result;
        }

        private static IEnumerable<EntityBase> ConvertLine(string line, FileConverterResult result)
        {
            TextFieldParser parser = new(new StringReader(line));

            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            var columns = parser.ReadFields();


            var servicoPrincipal = new ColumnsConverter<Servico>(columns)
                        .Convert(24, x => x.Codigo, long.Parse)
                        .Convert(25, x => x.Descricao)
                        .SetValue(x => x.Operadora, Operadora.SulAmerica)
                        .Result;

            var servico = new ColumnsConverter<Servico>(columns)
                        .Convert(26, x => x.Codigo, long.Parse)
                        .Convert(27, x => x.Descricao)
                        .SetValue(x => x.Operadora, Operadora.SulAmerica)
                        .SetValue(x => x.Principal, servicoPrincipal.Codigo != default ? servicoPrincipal : null)
                        .Result;

            
            var evento = new ColumnsConverter<Evento>(columns)
                            .Convert(9, x => x.CodigoBeneficiario, long.Parse)
                            .Convert(13, x => x.CodigoPlano, long.Parse)
                            .Convert(17, x => x.NomePrestador)
                            .Convert(18, x => x.CNPJPrestador, long.Parse)
                            .Convert(19, x => x.CNPJPrestadorPrincipal, x => x != "." ? long.Parse(x) : null)
                            .Convert(20, x => x.CrmResponsavel, x => x != "0" ? long.Parse(x) : null)
                            .Convert(21, x => x.CrmSolicitante, x => x != "0" ? long.Parse(x) : null)
                            .Convert(22, x => x.CrmExecutante, x => x != "0" ? long.Parse(x) : null)
                            .Convert(23, x => x.CodigoGrupoEstatico, long.Parse)
                            .Convert(30, x => x.Atendimento)
                            .Convert(32, x => x.CategoriaAtendimento)
                            .Convert(34, x => x.PosicaoPrestador)
                            .Convert(35, x => x.ValorApresentado,x =>  decimal.Parse(x))
                            .Convert(36, x => x.ValorPago, decimal.Parse)
                            .Convert(37, x => x.ValorCoparticipacao, decimal.Parse)
                            .Convert(38, x => x.ValorEmpresa, decimal.Parse)
                            .Convert(39, x => x.ValorNaoReembolsado, decimal.Parse)
                            .Convert(40, x => x.DataAtendimento, DateTime.Parse)
                            .Convert(41, x => x.DataInternacao, value => DateTime.Parse(value))
                            .Convert(43, x => x.DescInternacao)
                            .Convert(44, x => x.QtdServicoCobrado, int.Parse)
                            .Convert(45, x => x.QtdServicoPago, int.Parse)
                            .Convert(47, x => x.CodigoDocumento, long.Parse)
                            .Convert(48, x => x.NumeroLote, x => x != "0" ? long.Parse(x) : null)
                            .Convert(49, x => x.NumeroGuia, long.Parse)
                            .Convert(50, x => x.TipoGuia, x => x != "0" ? x[0] : null)
                            .SetValue(x => x.Servico, servico)
                            .Result;


            var lista =  new List<EntityBase>() {
                evento
            };

            if (!ServicoExistente(servico, result)) lista.Add(servico);
            if (!ServicoExistente(servicoPrincipal, result)) lista.Add(servicoPrincipal);

            return lista;
        }

        private static bool ServicoExistente(Servico servicoPesquisa, FileConverterResult result)
        {
            return servicoPesquisa.Codigo == 0 || result.Sucessos.Any(x => x is Servico servico && servicoPesquisa.Codigo == servico.Codigo);
        }
    }
}
