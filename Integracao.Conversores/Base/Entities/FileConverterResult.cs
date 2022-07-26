using Integracao.Core.Base.Entities;

namespace Integracao.Conversores.Base.Entities
{
	public class FileConverterResult
	{
        public List<FileTypeRowConvertResult> Rows { get; }
        public bool Sucesso => !Rows.Any(x => x.Error);
        public FileConverterResult()
        {
            Rows = new List<FileTypeRowConvertResult>();
        }

        public IEnumerable<T> Get<T>() where T : EntityBase, new()
        {
            return Rows.Where(x => x is FileTypeRowConvertResult<T>)
                       .Select(x => x.Object as T);
        }

        public IEnumerable<object> Get(Type type)
        {
            var typeGeneric = typeof(FileTypeRowConvertResult<>).MakeGenericType(type);
            return Rows.Where(x => typeGeneric.IsAssignableTo(x.GetType()))
                       .Select(x => x.Object);
        }
    }

  
}

