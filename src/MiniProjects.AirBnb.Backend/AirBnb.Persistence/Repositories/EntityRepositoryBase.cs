using System.Linq.Expressions;
using AirBnb.Domain.Common.Entities;
using AirBnb.Domain.Exceptions;
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

        return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Gets multiple instances of <see cref="TEntity"/> by ids
    /// </summary>
    /// <param name="ids">Ids of entities to query</param>
    /// <param name="asNoTracking">Determines whether to track returned entities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task that returns collection of entity instances, otherwise null</returns>
    protected async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        initialQuery = initialQuery.Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
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
            await DbContext.SaveChangesAsync(cancellationToken);

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
            await DbContext.SaveChangesAsync(cancellationToken);

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
            await DbContext.SaveChangesAsync(cancellationToken);

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
                     throw new InvalidOperationException();

        DbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}