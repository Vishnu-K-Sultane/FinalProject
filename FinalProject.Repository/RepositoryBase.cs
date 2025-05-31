using System.Linq.Expressions;
using FinalProject.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext; // Context for accessing the database

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="repository">The database context.</param>
        public RepositoryBase(RepositoryContext repository) => repositoryContext = repository;

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public void Create(T entity) => repositoryContext.Set<T>().Add(entity);

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        public void Delete(T entity) => repositoryContext.Set<T>().Remove(entity);

        /// <summary>
        /// Retrieves all entities, optionally tracking changes.
        /// </summary>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>An IQueryable of all entities.</returns>
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? repositoryContext.Set<T>().AsNoTracking() : repositoryContext.Set<T>();
        }

        /// <summary>
        /// Retrieves entities based on a condition, optionally tracking changes.
        /// </summary>
        /// <param name="condition">The condition to filter entities.</param>
        /// <param name="trackChanges">Indicates whether to track changes.</param>
        /// <returns>An IQueryable of entities that match the condition.</returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges) =>
            !trackChanges ?
            repositoryContext.Set<T>()
            .Where(condition)
            .AsNoTracking() :
            repositoryContext.Set<T>()
            .Where(condition);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public void Update(T entity) => repositoryContext.Set<T>().Update(entity);
    }
}
