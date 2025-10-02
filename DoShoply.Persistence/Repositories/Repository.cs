using System.Linq.Expressions;
using DoShoply.Domain.Extensions;
using DoShoply.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using DoShoply.Core.Interfaces.IRepositories;

namespace DoShoply.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<T> Add(T entity)
        {
            await Table.AddAsync(entity);

            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                return null; 
        }

        public async Task DeleteById(Guid id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                Table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entities = await Table.ToListAsync();
            if(entities != null)
                return entities;

            return null;
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
                return null;

            return entity;

        }

        public async Task<PageResult<T>> GetPagedResult(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<T> query = Table.AsQueryable();
            if(filter != null)
                query = query.Where(filter);

            int totalCount = await query.CountAsync();
            if (orderBy != null)
                query = orderBy(query);

            List<T> items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PageResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public Task<bool> IsAnyItem(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (filter != null)
                query = query.Where(filter);
            return query.AnyAsync();
        }

        public async Task<T> Update(Guid id, T entity)
        {
            var exists = await Table.FindAsync(id);
            if (exists == null)
                return null;

            _context.Entry(exists).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
