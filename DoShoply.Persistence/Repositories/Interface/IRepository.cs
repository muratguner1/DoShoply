using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoShoply.Domain.Extensions;

namespace DoShoply.Persistence.Repositories.Interface
{
    public interface IRepository<T> where T : new()
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(Guid id, T entity);
        Task DeleteById(Guid id);
        Task<PageResult<T>> GetPagedResult(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int pageNumber = 1, int pageSize = 10);
    }
}
