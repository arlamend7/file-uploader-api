using Integracao.Conversores.Base.Entities;
using Integracao.Conversores.Base.Exceptions;
using Integracao.Core.Base.Entities;
using Integracao.Domain.Eventos.Entities;
using Integracao.Domain.Servicos.Entidades;

namespace Integracao.Conversores.Sul_America.Eventos
{
    public class EventoConverter
    {
        private static readonly List<Type> types = new List<Type>()
            {
                typeof(Evento),
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
                    result.Sucessos.AddRange(ConvertLine(lines[i]));
                }
                catch (FileConverterColumnException ex)
                {
                    result.Erros.Add(new FileConverterLineException(i, ex));
                }
            }

            return result;
        }

        private static IEnumerable<EntityBase> ConvertLine(string line)
        {
            IEnumerable<string> columns = line.Replace(", 12:00:00 AM", "")
                                              .Split(",")
                                              .Select(x => x.Replace('"', ' ')
                                                            .Replace(@"\", "")
                                              .Trim());

            var evento = new ColumnsConverter<Servico>(columns);

            return new List<EntityBase>() { };
        }
    }
}
