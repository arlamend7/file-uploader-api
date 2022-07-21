using Integracao.Conversores.Base.Delegates;
using Integracao.Domain.Importacoes.Enumeradores;

namespace Integracao.Conversores.Base.Interfaces
{

    public interface IOperadoraConverter
    {
        FileConvert IdentificaArquivo(ClasseArquivoEnum arquivo);
    }
}
