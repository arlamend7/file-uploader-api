using System;
namespace Integracao.Application.Importacoes.DatasTransfer.Responses
{
	public class FileConverterResultResponse
	{
        public IEnumerable<FileTypeRowConvertResultResponse> Rows { get; set; }
        public bool Sucesso { get; set; }
    }
}

