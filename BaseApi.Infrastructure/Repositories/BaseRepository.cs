using BaseApi.Application.Interfaces.Repositories;
using BaseApi.Domain.Common;
using BaseApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext _applicationDbContext;

        protected BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity, cancellationToken);
        }

        public virtual async void Update(T entity)
        {
            _applicationDbContext.Set<T>().Remove(entity);
        }

        public virtual async void Delete(T entity)
        {
            _applicationDbContext.Set<T>().Update(entity);
        }
    }
}
