using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Common.Exceptions;

namespace AirBnb.Domain.Exceptions;

/// <summary>
/// Represents entity conflict exception
/// </summary>
public class EntityConflictException<TEntity>(Guid entityId, Exception innerException) : EntityExceptionBase(
    entityId,
    $"Entity {typeof(TEntity).Name} with id {entityId} has conflicts to execute this operation",
    innerException,
    ExceptionVisibility.Protected
) where TEntity : IEntity;