using BaseApi.Application.DTOs.Clients;
using BaseApi.Application.Wrapper;
using BaseApi.Domain.Common;
using BaseApi.Domain.Entities;

namespace BaseApi.Application.Interfaces.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<PagedResult<Client>> GetFilteredAsync(ClientFilterDto filter, Pagination pagination,CancellationToken cancellationToken = default);
        Task<Client?> GetByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
