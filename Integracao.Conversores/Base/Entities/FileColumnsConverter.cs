using System.Linq.Expressions;

namespace Integracao.Conversores.Base.Entities
{
	public class FileColumnsConverter<T> where T : new()
	{
        public IEnumerable<string> Columns { get; }
        public FileTypeRowConvertResult<T> Result { get; }

        public FileColumnsConverter(int line, IEnumerable<string> columns)
        {
            Columns = columns;
            Result = new FileTypeRowConvertResult<T>(line);
        }


        public FileColumnsConverter<T> Convert<TValue>(int columnIndex, Expression<Func<T, TValue>> prop, Func<string, TValue> func)
        {
            SetValue(columnIndex, prop, func);
            return this;
        }

        public FileColumnsConverter<T> Convert(int columnIndex, Expression<Func<T, string>> prop)
        {
            SetValue(columnIndex, prop, x => x);
            return this;
        }

        public FileColumnsConverter<T> Convert(int columnIndex, Expression<Func<T, char>> prop)
        {
            SetValue(columnIndex, prop, x => x[0]);
            return this;
        }

        public FileColumnsConverter<T> SetValue<TValue>(Expression<Func<T, TValue>> prop, TValue value)
        {
            SetValue(null ,prop, x => value);
            return this;
        }

        private void SetValue<TValue>(int? columnIndex, Expression<Func<T, TValue>> prop, Func<string, TValue> func)
        {
            var propertyName = (prop.Body as MemberExpression).Member.Name;
            string value = null;
            bool hasValue = true;

            if (columnIndex.HasValue)
            {
                value = Columns.ElementAt(columnIndex.Value);
                hasValue = !string.IsNullOrWhiteSpace(value);
            }

            var result = hasValue ? func(value) : default;
            try
            {
                Result.SetValue(propertyName, result);
                Result.Cells.Add(new FileColumnConvertSuccessResult<TValue>(columnIndex, result, propertyName));
            }
            catch (Exception ex)
            {
                Result.Cells.Add(new FileColumnConvertErrorResult<TValue>(columnIndex, value, propertyName, ex));
            }
        }

    }
}
