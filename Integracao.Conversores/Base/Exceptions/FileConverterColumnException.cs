namespace Integracao.Conversores.Base.Exceptions
{
    public class FileConverterColumnException : Exception
    {
        public int Coluna { get; set; }
        public string Value { get; set; }
        public Type Type { get; set; }
        public string Propriedade { get; set; }
        public string TypeName => Type.Name;

        public FileConverterColumnException(int coluna, string propriedade, string value, Type type, Exception exception) : base("conversao para coluna exception", exception)
        {
            Coluna = coluna;
            Type = type;
            Propriedade = propriedade;
            Value = value;
        }
    }
}

