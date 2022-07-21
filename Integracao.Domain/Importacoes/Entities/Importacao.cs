using Integracao.Core.Base.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Entities;

namespace Integracao.Domain.Importacoes.Entities
{
	public class Importacao : EntityBase
	{
        public string NomeArquivo { get; set; }
        public int Tamanho { get; set; }
        public ClasseArquivoEnum Classe { get; set; }
        public Operadora Operadora { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

