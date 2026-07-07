using BaseApi.Domain.Entities;

namespace BaseApi.Application.Interfaces.Repositories
{
    public interface IClientTypeRepository : IBaseRepository<ClientTypeTable>
    {
        Task<List<ClientTypeTable>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
