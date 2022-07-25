namespace Integracao.Conversores.Base.Entities
{
    public abstract class FileColumnConvertResult
    {
        public int? Column { get; }
        public string Value { get; }
        public string Property { get; }
        public string TypeName => Type.Name;
        public bool HasValue => !string.IsNullOrWhiteSpace(Value);
        public abstract Type Type { get; }
        public bool Success { get; protected set; }

        protected FileColumnConvertResult(int? column, string value, string property)
        {
            Column = column;
            Value = value;
            Property = property;
        }
    }
    public abstract class FileColumnConvertResult<T> : FileColumnConvertResult
    {
        public override Type Type => typeof(T);
        protected FileColumnConvertResult(int? column, string value, string property) : base(column, value, property)
        {
        }

    }

    public class FileColumnConvertSuccessResult<T> : FileColumnConvertResult<T>
    {
        public FileColumnConvertSuccessResult(int? column, T value, string property) : base(column, value?.ToString(), property)
        {
            Success = true;
        }
    }

    public class FileColumnConvertErrorResult<T> : FileColumnConvertResult<T>
    {

        public string ErrorMessage { get; }
        public FileColumnConvertErrorResult(int? column, string value, string property, Exception exception) : base(column, value, property)
        {
            ErrorMessage = exception.Message;
            Success = false;
        }
    }
}

