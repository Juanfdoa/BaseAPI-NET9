using BaseApi.Domain.Entities;

namespace BaseApi.Application.Interfaces.Repositories
{
    public interface IClientTypeRepository : IBaseRepository<ClientType>
    {
        Task<List<ClientType>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
