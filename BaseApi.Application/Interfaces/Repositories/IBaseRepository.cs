namespace BaseApi.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        void Update(T entity);

        void Delete(T entity);
    }
}
