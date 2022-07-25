using System;
namespace Integracao.Application.Importacoes.DatasTransfer.Responses
{
	public class FileColumnConvertResultResponse
	{
        public int? Column { get; set; }
        public string Value { get; set; }
        public string Property { get; set; }
        public string TypeName { get; set; }
        public bool HasValue { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}

