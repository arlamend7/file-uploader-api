using Integracao.Conversores.Base.Entities;
using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Base.Interfaces
{
    public interface IOperadoraConverter
    {
        Func<Stream, FileConverterResult> IdentificaArquivo(string arquivo);
    }
}
