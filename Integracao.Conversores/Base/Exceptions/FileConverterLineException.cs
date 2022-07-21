using System;
namespace Integracao.Conversores.Base.Exceptions
{
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
}

