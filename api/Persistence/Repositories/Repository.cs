using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> Get()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic async Get method for entities
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? pageNumber = null,
            int? pageSize = null,
            Expression<Func<TEntity, object>>[] navigationProperties = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filter != null)
                query = query.Where(filter);

            if (navigationProperties != null)
                foreach (var navigationProperty in navigationProperties)
                    query = query.Include(navigationProperty);

            if (orderBy != null)
            {
                // TODO: 
                if (pageSize != null && pageSize > 0 && pageNumber != null && pageNumber > 0)
                {
                    var excludedRows = (pageNumber - 1) * pageSize;
                    return orderBy(query).ToList().Skip((int)excludedRows).Take((int)pageSize);
                }
                return orderBy(query).ToList();
            }

            return await query.ToListAsync();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic async Get method on the basis of id for entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Asynchronously Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleAsync(predicate);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Get asynchronously when you expect zero or one items to be returned by a query (i.e. you are not sure if an item
        ///     with a given key exists).
        ///     This will throw an exception if the query does not return zero or one items.
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria or Null</returns>
        public async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Asynchronously Get the first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstAsync(predicate);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Asynchronously Get the first or default record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return Context.Set<TEntity>().Where(where).ToList();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic method to get many record on the basis of a condition but queryable.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return Context.Set<TEntity>().Where(where).AsQueryable();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Include multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate,
            params string[] include)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic Insert method for the collection of entities
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic Delete method for the entities by entity Id
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            var entityToDelete = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entityToDelete);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
                Context.Set<TEntity>().Attach(entityToDelete);
            Context.Set<TEntity>().Remove(entityToDelete);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic Delete method for a collection of entities
        /// </summary>
        /// <param name="entitiesToDelete"></param>
        public virtual void Delete(IEnumerable<TEntity> entitiesToDelete)
        {
            Context.Set<TEntity>().RemoveRange(entitiesToDelete);
        }

        /// <inheritdoc/>
        /// <summary>
        ///     Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        /// <param name="rowVersion"></param>
        public virtual void Update(TEntity entityToUpdate, byte[] rowVersion)
        {
            Context.Set<TEntity>().Attach(entityToUpdate);
            if (rowVersion != null) Context.Entry(entityToUpdate).OriginalValues["RowVersion"] = rowVersion;
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic async method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(object primaryKey)
        {
            return await Context.Set<TEntity>().FindAsync(primaryKey) != null;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic async Count method with filter without loading the entities
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> CountAsync(
            Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return filter != null ? await query.CountAsync(filter) : await query.CountAsync();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Generic async bulk update method for the entities
        /// </summary>
        /// <param name="entitiesToUpdate"></param>
        //public virtual async Task BulkUpdateAsync(IEnumerable<TEntity> entitiesToUpdate)
        //{
        //    await Context.BulkUpdateAsync(entitiesToUpdate, option => option.Log += s => NLogger.Logger.Debug(s));
        //}

        /// <inheritdoc />
        /// <summary>
        ///     Generic async bulk insert method for the entities
        /// </summary>
        /// <param name="entitiesToInsert"></param>
        //public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entitiesToInsert)
        //{
        //    await Context.BulkInsertAsync(entitiesToInsert, option => option.Log += s => NLogger.Logger.Debug(s));
        //}

        /// <inheritdoc />
        /// <summary>
        ///     Generic async bulk delete method for the entities
        /// </summary>
        /// <param name="entitiesToDelete"></param>
        //public virtual async Task BulkDeleteAsync(IEnumerable<TEntity> entitiesToDelete)
        //{
        //    await Context.BulkDeleteAsync(entitiesToDelete, option => option.Log += s => NLogger.Logger.Debug(s));
        //}
    }
}

