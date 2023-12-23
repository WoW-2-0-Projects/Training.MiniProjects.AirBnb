using System.Linq.Expressions;
using AirBnb.Domain.Extensions;
using Microsoft.EntityFrameworkCore.Query;

namespace AirBnb.Persistence.Caching.Models;

/// <summary>
/// Represents a resolver for cache key.
/// </summary>
public readonly struct EfCoreExpressionCacheKeyResolver : IExpressionCacheKeyResolver
{
    public string GetCacheKey<T>(Expression expression, Type? actualType = default)
    {
        if (actualType is null)
        {
            var resultType = typeof(T);
            actualType = resultType;

            // Determine actual type
            var isTask = resultType.IsTask();
            if (isTask) actualType = resultType.GetGenericArgument()!;
            if (actualType.IsCollection()) actualType = resultType.GetGenericArgument();
        }

        var expressionEqualityComparer = ExpressionEqualityComparer.Instance;
        var hashCode = expressionEqualityComparer.GetHashCode(expression);
        var postFix = actualType!.IsCollection() ? "Multiple" : "Single";
        return $"{actualType!.Name}_{postFix}_{hashCode}";
    }
}