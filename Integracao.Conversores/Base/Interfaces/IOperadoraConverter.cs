using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Importacoes.Enumeradores;

namespace Integracao.Conversores.Base.Interfaces
{

    public interface IOperadoraConverter
    {
        IOperadoraFileConverter IdentificaArquivo(ClasseArquivoEnum arquivo);
    }
}
