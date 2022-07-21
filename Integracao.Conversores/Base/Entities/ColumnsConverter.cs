using System.Linq.Expressions;

namespace Integracao.Conversores.Base.Entities
{
	public class ColumnsConverter<T> where T : new()
	{
        public IEnumerable<string> Columns { get; set; }

        public T Entity { get; set; }
        public Type Type = typeof(T);


        public ColumnsConverter(IEnumerable<string> columns)
        {
            Columns = columns;
            Entity = new T();
        }


        public ColumnsConverter<T> Convert<TValue>(int columnIndex, Expression<Func<T, TValue>> prop, Func<string, TValue> func)
        {
            SetValue(columnIndex, prop, func);
            return this;
        }

        public ColumnsConverter<T> Convert(int columnIndex, Expression<Func<T, string>> prop)
        {
            SetValue(columnIndex, prop, x => x);
            return this;
        }

        public ColumnsConverter<T> Convert(int columnIndex, Expression<Func<T, char>> prop)
        {
            SetValue(columnIndex, prop, x => x[0]);
            return this;
        }

        private void SetValue<TValue>(int columnIndex, Expression<Func<T, TValue>> prop, Func<string, TValue> func)
        {
            var propertyName = (prop.Body as MemberExpression).Member.Name;
            var value = Columns.ElementAt(columnIndex);
            try
            {
                Type.GetProperty(propertyName).SetValue(Entity, string.IsNullOrWhiteSpace(value) ? default : func(value));
            }
            catch (Exception ex)
            {
                throw new FileConverterColumnException(columnIndex, propertyName, value, typeof(TValue), ex);
            }
        }

        public T Result => Entity;
    }
}
