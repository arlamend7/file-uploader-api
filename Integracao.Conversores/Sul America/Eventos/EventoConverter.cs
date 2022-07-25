using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Exceptions;
using Integracao.Conversores.Base.Interfaces;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Eventos.Entities;
using Integracao.Domain.Importacoes.Entities;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Servicos.Entidades;
using Microsoft.VisualBasic.FileIO;

namespace Integracao.Conversores.Sul_America.Eventos
{
    public class EventoConverter : IOperadoraFileConverter
    {

        public IEnumerable<Type> OutTypes => new List<Type>()
            {
                typeof(Evento),
                typeof(Servico)
            };

        public FileConverterResult Convert(Stream file, Importacao importacao)
        {
            StreamReader sr = new(file);
            string[] lines = sr.ReadToEnd().Split("\n");

            FileConverterResult result = new();

            for (int i = 1; i < lines.Length - 1; i++)
            {
                var line = lines[i];
                result.Rows.AddRange(ConvertLine(i, line, importacao, result));
            }

            return result;
        }

        private static IEnumerable<FileTypeRowConvertResult> ConvertLine(int indexLine, string line, Importacao importacao, FileConverterResult result)
        {
            string[] columns = new TextFieldParser(new StringReader(line))
            {
                HasFieldsEnclosedInQuotes = true,
                Delimiters = new string[] { "," }
            }.ReadFields();

            var servicoPrincipal = new FileColumnsConverter<Servico>(indexLine, columns)
                        .Convert(24, x => x.Codigo, long.Parse)
                        .Convert(25, x => x.Descricao)
                        .SetValue(x => x.Operadora, Operadora.SulAmerica)
                        .SetValue(x => x.Importacao, importacao)
                        .Result;

            var servico = new FileColumnsConverter<Servico>(indexLine, columns)
                        .Convert(26, x => x.Codigo, long.Parse)
                        .Convert(27, x => x.Descricao)
                        .SetValue(x => x.Operadora, Operadora.SulAmerica)
                        .SetValue(x => x.Principal, servicoPrincipal.Entity.Codigo != default ? servicoPrincipal.Entity : null)
                        .SetValue(x => x.Importacao, importacao)
                        .Result;

            
            var evento = new FileColumnsConverter<Evento>(indexLine, columns)
                            .Convert(09, x => x.CodigoBeneficiario, long.Parse)
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
                            .SetValue(x => x.Servico, servico.Entity)
                            .SetValue(x => x.Importacao, importacao)

                            .Result;


            var lista =  new List<FileTypeRowConvertResult>() {
                evento
            };

            if (!ServicoExistente(servico, result)) lista.Add(servico);
            if (!ServicoExistente(servicoPrincipal, result)) lista.Add(servicoPrincipal);

            return lista;
        }

        private static bool ServicoExistente(FileTypeRowConvertResult<Servico> servicoPesquisa, FileConverterResult result)
        {
            return servicoPesquisa.Entity.Codigo == 0 || result.Rows.Any(x => x is FileTypeRowConvertResult<Servico> servico && servicoPesquisa.Entity.Codigo == servico.Entity.Codigo);
        }
    }
}
