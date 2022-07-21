using System;
using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Base.Entities
{
	public class FileConverterResult
	{
        public List<EntityBase> Sucessos { get; set; }
        public List<FileConverterLineException> Erros { get; set; }
        public bool Sucesso => !Erros.Any();
        public FileConverterResult()
        {
            Sucessos = new List<EntityBase>();
            Erros = new List<FileConverterLineException>();
        }
    }

    public class FileConverterLineException : Exception
    {
        public int Linha { get; set; }
        public FileConverterColumnException Coluna { get; set; }
        public FileConverterLineException(int line, FileConverterColumnException ex) 
        {
            Linha = line;
            Coluna = ex;
        }
    }
    public class FileConverterColumnException : Exception
    {
        public int Coluna { get; set; }
        public string Value { get; set; }
        public Type Type { get; set; }
        public string Propriedade { get; set; }
        public string TypeName => Type.Name;

        public FileConverterColumnException(int coluna, string propriedade, string value, Type type , Exception exception) : base("conversao para coluna exception",exception)
        {
            Coluna = coluna;
            Type = type;
            Propriedade = propriedade;
            Value = value;
        }
    }
}

