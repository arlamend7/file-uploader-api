using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Base.Interfaces
{
    public interface IOperadoraConverter
    {
        Func<Stream,IEnumerable<EntityBase>> IdentificaArquivo(string arquivo);
    }
}
