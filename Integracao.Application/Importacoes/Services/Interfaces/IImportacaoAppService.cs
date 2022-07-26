using Integracao.Application.Importacoes.DatasTransfer.Requests;
using Integracao.Application.Importacoes.DatasTransfer.Responses;
using Integracao.Conversores.Base.Entities;

namespace Integracao.Application.Importacoes.Interfaces
{
    public interface IImportacaoAppService
    {
        FileConverterResultResponse ValidateFile(Stream arquivo, FileImportInsertRequest request);
        Guid InsertValuesFile(string fileName, Stream arquivo, FileImportInsertRequest request);
    }
}
