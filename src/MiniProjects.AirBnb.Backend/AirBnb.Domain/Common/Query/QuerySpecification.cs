using System.Linq.Expressions;
using AirBnb.Domain.Common.Caching;
using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Comparers;
using Microsoft.EntityFrameworkCore.Query;

namespace AirBnb.Domain.Common.Query;

/// <summary>
/// Represents a query specification for retrieving entities from a cache.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public class QuerySpecification<TEntity>(uint pageSize, uint pageToken) : CacheModel where TEntity : IEntity
{
    /// <summary>
    /// Gets filtering options collection for query.
    /// </summary>
    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = [];

    /// <summary>
    /// Gets ordering options collection for query.
    /// </summary>
    public List<(Expression<Func<TEntity, object>> KeySelector, bool IsAscending)> OrderingOptions { get; } = [];

    /// <summary>
    /// Gets pagination options for query.
    /// </summary>
    public FilterPagination PaginationOptions { get; } = new(pageSize, pageToken);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        var expressionEqualityComparer = ExpressionEqualityComparer.Instance;

        foreach (var filteringExpression in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(expressionEqualityComparer.GetHashCode(filteringExpression));

        foreach (var orderingExpression in OrderingOptions)
            hashCode.Add(expressionEqualityComparer.GetHashCode(orderingExpression.KeySelector));

        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }

    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";
}