using System;
namespace Integracao.Application.Importacoes.DatasTransfer.Responses
{
	public class FileTypeRowConvertResultResponse
	{
        public int Line { get; set; }
        public string TypeName { get; set; }
        public IEnumerable<FileColumnConvertResultResponse> Cells { get; set; }
        public bool Error { get; set; }
    }
}

