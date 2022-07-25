
namespace Integracao.Conversores.Base.Entities
{

    public abstract class FileTypeRowConvertResult
    {
        public int Line { get; }
        public abstract Type Type { get; }
        public string TypeName => Type.Name;
        public List<FileColumnConvertResult> Cells { get; }
        public bool Error => Cells.Any(x => !x.Success);
        public object Object { get; protected set; }


        public FileTypeRowConvertResult(int line)
        {
            Line = line;
            Cells = new List<FileColumnConvertResult>();
        }
    }

    public class FileTypeRowConvertResult<T> : FileTypeRowConvertResult
        where T : new()
	{
        public T Entity => (T)Object;

        public override Type Type => typeof(T);

        public FileTypeRowConvertResult(int line) : base(line)
        {
            Object = new T();
        }

        public void SetValue<TValue>(string propertyName, TValue value)
        {
            Type.GetProperty(propertyName).SetValue(Object, value);
        }
    }
}

