using OGA.DomainBase.QueryHelpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OGA.DomainBase.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class, OGA.DomainBase.Models.IAggregateRoot<TId> where TId : IEquatable<TId>
    {
        bool Add(TEntity entity);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        bool RemoveById(TId id);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);

        bool Update_ById(TId id, Dictionary<string, string> changes);
        bool Update(TEntity entity);
        Task<bool> Upsert(TEntity entity);

        TEntity GetById(TId id);
        Task<TEntity> GetByIdAsync(TId id);
        IEnumerable<TEntity> Get_byIDList(IEnumerable<TId> ids);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IPaginatedList<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams);
        Task<IPaginatedList<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate);
        Task<IPaginatedList<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams, IQueryable<TEntity> query);
        Task<IPaginatedList<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams, List<Expression<Func<TEntity, object>>> includes);
        Task<IPaginatedList<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams, Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>> includes = null);
    }
}
