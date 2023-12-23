using System.Collections;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace AirBnb.Persistence.Caching.Models;

/// <summary>
/// Represents cached queryable source
/// </summary>
/// <param name="queryableSource">Base queryable source</param>
/// <param name="asyncQueryProvider">Async query provider resolver</param>
/// <param name="queryCacheBroker">Query cache resolver used for caching</param>
/// <typeparam name="TSource">The root type of source</typeparam>
/// <typeparam name="TQueryable">Type of base queryable source</typeparam>
public class CachedQueryable<TSource, TQueryable>(
    TQueryable queryableSource,
    IAsyncQueryProviderResolver asyncQueryProvider,
    IExpressionCacheKeyResolver expressionCacheKeyResolver,
    IQueryCacheBroker queryCacheBroker
) : IQueryable<TSource>, IAsyncEnumerable<TSource> where TQueryable : IQueryable<TSource>, IAsyncEnumerable<TSource>
{
    public IEnumerator<TSource> GetEnumerator() => queryableSource.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public Type ElementType { get; } = queryableSource.ElementType;

    public Expression Expression { get; } = queryableSource.Expression;

    public IQueryProvider Provider { get; } = new CachedQueryProvider(asyncQueryProvider.Get(), expressionCacheKeyResolver, queryCacheBroker);

    public IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken cancellationToken = default) =>
        ((IAsyncQueryProvider)Provider).ExecuteAsync<IAsyncEnumerable<TSource>>(Expression, cancellationToken).GetAsyncEnumerator(cancellationToken);
}