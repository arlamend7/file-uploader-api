using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Application.Importacoes.Interfaces
{
    public interface IImportacaoAppService
    {
        void ImportarArquivos(string nomeArquivo, Stream arquivo, OperadorasEnum operadora);
    }
}
