using System;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Application.Importacoes.DatasTransfer.Requests
{
	public class FileImportInsertRequest
	{
        public ClasseArquivoEnum Classe { get; set; }
        public OperadoraEnum Operadora { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}

