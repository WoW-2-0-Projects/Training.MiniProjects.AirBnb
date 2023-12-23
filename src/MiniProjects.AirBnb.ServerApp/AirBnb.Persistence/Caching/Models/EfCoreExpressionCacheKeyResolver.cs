using System.Linq.Expressions;
using AirBnb.Domain.Constants;
using AirBnb.Domain.Extensions;

namespace AirBnb.Persistence.Caching.Models;

/// <summary>
/// Represents a resolver for cache key.
/// </summary>
public readonly struct EfCoreExpressionCacheKeyResolver : IExpressionCacheKeyResolver
{
    public string GetCacheKey<T>(Expression expression, Type? actualType = default)
    {
        var resultType = typeof(T);
        var isCollection = resultType.IsCollection();

        if (actualType is null)
        {
            actualType = resultType;

            // Determine actual type
            var isTask = resultType.IsTask();
            if (isTask) actualType = resultType.GetGenericArgument()!;
            if (actualType.IsCollection()) actualType = resultType.GetGenericArgument();
        }

        var instance = new ExpressionHashCodeVisitor();
        instance.Visit(expression);
        var hashCode = instance.HashSum;

        var postFix = isCollection
            ? InfrastructureConstants.CachingConstants.MultipleEntryPrefix
            : InfrastructureConstants.CachingConstants.SingleEntryPrefix;
        return $"{actualType!.Name}_{postFix}_{hashCode}";
    }
}