using BasicShopDemo.Api.Core.DTO;
using StringToExpression.LanguageDefinitions;
using System;
using System.Linq;

namespace BasicShopDemo.Api.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyQuery<T>(this IQueryable<T> parentQuery, Query query)
        {
            if (query == null)
            {
                return parentQuery;
            }

            return parentQuery
                .ApplyFilter(query.Filter)
                .ApplySkip(query.Skip, query.Take);
        }

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return query;
            }

            try
            {
                var compiledFilter = new ODataFilterLanguage().Parse<T>(filter);

                return query.Where(compiledFilter);
            }
            catch (Exception e)
            {
                throw new FormatException($"Provided filter expression '{filter}' has incorrect format", e);
            }
        }

        public static IQueryable<T> ApplySkip<T>(this IQueryable<T> query, uint? skip, uint? take)
            => query
                .SkipIf(skip.HasValue, (int)skip.GetValueOrDefault())
                .TakeIf(take.HasValue, (int)take.GetValueOrDefault());

        private static IQueryable<T> SkipIf<T>(this IQueryable<T> query, bool predicate, int skip)
            => predicate ? query.Skip(skip) : query;

        private static IQueryable<T> TakeIf<T>(this IQueryable<T> query, bool predicate, int skip)
            => predicate ? query.Take(skip) : query;
    }
}
