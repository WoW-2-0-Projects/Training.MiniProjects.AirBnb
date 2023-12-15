using System.Linq.Expressions;
using AirBnb.Domain.Common.Caching;
using AirBnb.Domain.Comparers;
using Microsoft.EntityFrameworkCore.Query;

namespace AirBnb.Domain.Common.Query;

/// <summary>
/// Represents a query specification for retrieving entities from a cache.
/// </summary>
/// <typeparam name="TSource">The type of source.</typeparam>
public class QuerySpecification<TSource>(uint pageSize, uint pageToken, bool asNoTracking) : CacheModel
{
    /// <summary>
    /// Gets filtering options collection for query.
    /// </summary>
    public List<Expression<Func<TSource, bool>>> FilteringOptions { get; } = [];

    /// <summary>
    /// Gets ordering options collection for query.
    /// </summary>
    public List<(Expression<Func<TSource, object>> KeySelector, bool IsAscending)> OrderingOptions { get; } = [];

    /// <summary>
    /// Gets including options collection for query.
    /// </summary>
    public List<Expression<Func<TSource, object>>> IncludingOptions { get; } = [];

    /// <summary>
    /// Gets pagination options for query.
    /// </summary>
    public FilterPagination PaginationOptions { get; } = new(pageSize, pageToken);

    public bool AsNoTracking { get; } = asNoTracking;

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        var expressionEqualityComparer = ExpressionEqualityComparer.Instance;

        foreach (var filteringExpression in FilteringOptions.Order(new PredicateExpressionComparer<TSource>()))
            hashCode.Add(expressionEqualityComparer.GetHashCode(filteringExpression));

        foreach (var orderingExpression in OrderingOptions)
            hashCode.Add(expressionEqualityComparer.GetHashCode(orderingExpression.KeySelector));

        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TSource> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }

    public override string CacheKey => $"{typeof(TSource).Name}_{GetHashCode()}";
}