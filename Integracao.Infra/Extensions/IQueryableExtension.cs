using System;
using Integracao.Core.Base.Entities;

namespace Integracao.Infra.Extensions
{
	public static class IQueryableExtension
	{
		public static IQueryable<T> Contains<T>(this IQueryable<T> query, IEnumerable<long> codigos)
			where T : EntityBase
        {
			return query.Where(x => codigos.Contains(x.Codigo));
        }

		public static IEnumerable<T> Except<T>(this IEnumerable<T> list, IQueryable<T> query)
            where T : EntityBase
        {
            var codigos = list.Select(x => x.Codigo);
            return list.Except(query.Where(x => codigos.Contains(x.Codigo)));
        }
	}
}

