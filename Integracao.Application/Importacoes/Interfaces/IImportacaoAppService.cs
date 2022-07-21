using Integracao.Conversores.Base.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Application.Importacoes.Interfaces
{
    public interface IImportacaoAppService
    {
        FileConverterResult ImportarArquivos(ClasseArquivoEnum nomeArquivo, FileStream arquivo, OperadorasEnum operadora);
    }
}
