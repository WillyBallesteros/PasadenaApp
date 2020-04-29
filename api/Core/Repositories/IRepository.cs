using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Generic IQueryable Get method for Entities
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> Get();

        /// <summary>
        ///     Generic async Get method for entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? pageNumber = null,
            int? pageSize = null,
            Expression<Func<TEntity, object>>[] navigationProperties = null);

        /// <summary>
        ///     Generic async Get method on the basis of id for entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        ///     Asynchronously Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get asynchronously when you expect zero or one items to be returned by a query (i.e. you are not sure if an item with a given key exists). 
        /// This will throw an exception if the query does not return zero or one items.
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Asynchronously Get the first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Asynchronously Get the first or default record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);

        /// <summary>
        ///     Generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where);

        /// <summary>
        ///     Include multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate,
            params string[] include);

        /// <summary>
        ///     Generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        ///     Generic Insert method for the collection of entities
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Generic Delete method for the entities by entity Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        ///     Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        ///     Generic Delete method for a collection of entities
        /// </summary>
        /// <param name="entitiesToDelete"></param>
        void Delete(IEnumerable<TEntity> entitiesToDelete);

        /// <summary>
        ///     Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        ///   /// <param name="rowVersion"></param>
        void Update(TEntity entityToUpdate, byte[] rowVersion);

        /// <summary>
        ///     Generic async method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(object primaryKey);

        /// <summary>
        ///     Generic async Count method with filter without loading the entities
        /// </summary>
        /// <returns></returns>
        Task<int> CountAsync(
            Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        ///     Generic async bulk update method for the entities
        /// </summary>
        /// <param name="entitiesToUpdate"></param>
        //Task BulkUpdateAsync(IEnumerable<TEntity> entitiesToUpdate);

        /// <summary>
        ///     Generic async bulk insert method for the entities
        /// </summary>
        /// <param name="entitiesToInsert"></param>
        //Task BulkInsertAsync(IEnumerable<TEntity> entitiesToInsert);

        /// <summary>
        ///     Generic async bulk delete method for the entities
        /// </summary>
        /// <param name="entitiesToDelete"></param>
        //Task BulkDeleteAsync(IEnumerable<TEntity> entitiesToDelete);
    }
}
