using System.Linq.Expressions;
using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Exceptions;
using AirBnb.Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AirBnb.Persistence.Repositories;

/// <summary>
/// Provides base functionality for entity repositories
/// </summary>
/// <typeparam name="TEntity">Type of entity</typeparam>
/// <typeparam name="TContext">Type of context</typeparam>
public class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext
{
    /// <summary>
    /// Gets using <see cref="DbContext"/> instance
    /// </summary>
    protected TContext DbContext => (TContext)_dbContext;

    /// <summary>
    /// Stores <see cref="DbContext"/> instance
    /// </summary>
    private readonly DbContext _dbContext;

    protected EntityRepositoryBase(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets queryable of <see cref="TEntity"/>
    /// </summary>
    /// <param name="predicate">Predicate to filter</param>
    /// <param name="asNoTracking">Determines whether to track returned entities</param>
    /// <returns>Queryable of <see cref="TEntity"/></returns>
    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    /// <summary>
    /// Gets instance of <see cref="TEntity"/> by id
    /// </summary>
    /// <param name="id">Id of entity to query</param>
    /// <param name="asNoTracking">Determines whether to track returned entities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity instance if exists, otherwise null</returns>
    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return await ExecuteAsync(id, () => initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken));
    }

    /// <summary>
    /// Creates new instance of <see cref="TEntity"/>
    /// </summary>
    /// <param name="entity">Instance of entity to create</param>
    /// <param name="saveChanges">Determines whether save changes to context or to database</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task that returns created entity instance</returns>
    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        entity.Id = Guid.Empty;

        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if (saveChanges)
            await ExecuteAsync(entity.Id, () => DbContext.SaveChangesAsync(cancellationToken));

        return entity;
    }

    /// <summary>
    /// Updates existing instance of <see cref="TEntity"/>
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <param name="saveChanges">Determines whether save changes to context or to database</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task that returns updated entity instance</returns>
    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await ExecuteAsync(entity.Id, () => DbContext.SaveChangesAsync(cancellationToken));

        return entity;
    }

    /// <summary>
    /// Deletes existing instance of <see cref="TEntity"/>
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="saveChanges">Determines whether save changes to context or to database</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task that returns deleted entity instance if soft deletion is used, otherwise null</returns>
    protected async ValueTask<TEntity?> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await ExecuteAsync(entity.Id, () => DbContext.SaveChangesAsync(cancellationToken));

        return entity;
    }

    /// <summary>
    /// Deletes existing instance of <see cref="TEntity"/> by id
    /// </summary>
    /// <param name="id">Id of entity to delete</param>
    /// <param name="saveChanges">Determines whether save changes to context or to database</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task that returns deleted entity instance if soft deletion is used, otherwise null</returns>
    /// <exception cref="InvalidOperationException">If entity is not found</exception>
    protected async ValueTask<TEntity?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) ??
                     throw new EntityEntryNotFoundException<TEntity>(id);

        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await ExecuteAsync(entity.Id, () => DbContext.SaveChangesAsync(cancellationToken));

        return entity;
    }

    /// <summary>
    /// Executes the given data access function asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="T">The return type of the data access function.</typeparam>
    /// <param name="entityId">Id of entity</param>
    /// <param name="dataAccessFunc">The data access function to execute.</param>
    /// <returns>
    /// The result of the data access function.
    /// </returns>
    /// <exception cref="Exception">Thrown if the execution of the data access function fails.</exception>
    private static async ValueTask<T?> ExecuteAsync<T>(Guid entityId, Func<ValueTask<T?>> dataAccessFunc)
    {
        var result = await dataAccessFunc.GetValueAsync();
        if (!result.IsSuccess)
            throw MapEfCoreException(entityId, result.Exception!);

        return result.Data;
    }

    /// <summary>
    /// Executes the given data access function asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="T">The return type of the data access function.</typeparam>
    /// <param name="entityId">Id of entity</param>
    /// <param name="dataAccessFunc">The data access function to execute.</param>
    /// <returns>
    /// The result of the data access function.
    /// </returns>
    /// <exception cref="Exception">Thrown if the execution of the data access function fails.</exception>
    private static async ValueTask<T?> ExecuteAsync<T>(Guid entityId, Func<Task<T?>> dataAccessFunc)
    {
        var result = await dataAccessFunc.GetValueAsync();
        if (!result.IsSuccess)
            throw MapEfCoreException(entityId, result.Exception!);

        return result.Data;
    }

    /// <summary>
    /// Maps the given Entity Framework Core exception to a custom exception based on the entity and the exception type.
    /// </summary>
    /// <param name="entityId">Id of entity</param>
    /// <param name="exception">The original Entity Framework Core exception.</param>
    /// <returns>The mapped exception.</returns>
    private static Exception MapEfCoreException(Guid entityId, Exception exception)
    {
        return exception switch
        {
            DbUpdateConcurrencyException dbUpdateConcurrencyException => new EntityConflictException<TEntity>(entityId, dbUpdateConcurrencyException),
            DbUpdateException dbUpdateException => MapDbUpdateException(entityId, dbUpdateException),
            _ => exception
        };
    }

    /// <summary>
    /// Maps a <see cref="DbUpdateException"/> to the corresponding entity exception.
    /// </summary>
    /// <param name="entityId">Id of entity</param>
    /// <param name="exception">The <see cref="DbUpdateException"/> to be handled.</param>
    /// <returns>The mapped <see cref="Exception"/>.</returns>
    /// <exception cref="EntityConflictException{TEntity}">Thrown when the <paramref name="exception"/> represents a foreign key or unique constraint violation.</exception>
    /// <exception cref="EntityExceptionBase">Thrown when the <paramref name="exception"/> is not related to a constraint violation.</exception>
    private static EntityExceptionBase MapDbUpdateException(Guid entityId, DbUpdateException exception)
    {
        if (exception.InnerException is not NpgsqlException postgresException)
            return new EntityExceptionBase(entityId, innerException: exception);

        switch (postgresException.ErrorCode)
        {
            case 547: // foreign key constraint violation
            case 2601: // unique constraint violation for index
            case 2627: // unique constraint violation for primary key
                throw new EntityConflictException<TEntity>(entityId, exception);
            default:
                throw new EntityExceptionBase(entityId, innerException: exception);
        }
    }
}