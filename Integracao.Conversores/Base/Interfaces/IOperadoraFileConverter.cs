using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Importacoes.Entities;

namespace Integracao.Conversores.Base.Interfaces
{
	public interface IOperadoraFileConverter
	{
        IEnumerable<Type> OutTypes { get; }

        FileConverterResult Convert(Stream file, Importacao importacao);
    }
}

