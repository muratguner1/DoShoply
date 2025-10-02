using System.Linq.Expressions;
using DoShoply.Domain.Extensions;

namespace DoShoply.Core.Interfaces.IRepositories
{
    public interface IRepository<T> where T : new()
    {
        Task<T> GetById(Guid id);
        Task<bool> IsAnyItem(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(Guid id, T entity);
        Task DeleteById(Guid id);
        Task<PageResult<T>> GetPagedResult(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int pageNumber = 1, int pageSize = 10);
    }
}
