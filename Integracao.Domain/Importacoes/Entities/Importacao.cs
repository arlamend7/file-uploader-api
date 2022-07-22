using Integracao.Core.Base.Entities;
using Integracao.Domain.Importacoes.Enumeradores;
using Integracao.Domain.Operadoras.Entities;
using Integracao.Domain.Operadoras.Enums;

namespace Integracao.Domain.Importacoes.Entities
{
	public class Importacao : EntityBase
	{
        public Importacao(string nomeArquivo, long tamanho, ClasseArquivoEnum classe, OperadoraEnum operadora, int month, int year)
        {
            NomeArquivo = nomeArquivo;
            Tamanho = tamanho;
            Classe = classe;
            Operadora = operadora;
            Year = year;
            Month = month;
        }

        protected Importacao()
        {

        }
        public virtual string NomeArquivo { get; set; }
        public virtual long Tamanho { get; set; }
        public virtual ClasseArquivoEnum Classe { get; set; }
        public virtual OperadoraEnum Operadora { get; set; }
        public virtual DateTime InsertDate { get; set; } = DateTime.Now;
        public virtual int Year { get; set; }
        public virtual int Month { get; set; }
    }
}

