using BaseApi.Application.DTOs.Clients;
using BaseApi.Application.Interfaces.Repositories;
using BaseApi.Application.Wrapper;
using BaseApi.Domain.Common;
using BaseApi.Domain.Entities;
using BaseApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<Client>> GetFilteredAsync(ClientFilterDto filter, Pagination pagination, CancellationToken cancellationToken = default)
        {
            IQueryable<Client> query = _context.Clients.Include(x => x.ClientType);

            if (!string.IsNullOrWhiteSpace(filter.Code))
                query = query.Where(x => EF.Functions.ILike(x.City, $"%{filter.Code}%"));

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => EF.Functions.ILike(x.Name, $"%{filter.Name}%"));

            if (!string.IsNullOrWhiteSpace(filter.Type))
                query = query.Where(x => EF.Functions.ILike(x.ClientType.Name, $"%{filter.Type}%"));


            var totalRecords = await query.CountAsync(cancellationToken);

            var clients = await query
                .OrderBy(x => x.Name)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Client>
            {
                Items = clients,
                TotalRecords = totalRecords
            };
        }
        public async Task<Client?> GetByIdWithIncludesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Clients.Include(x => x.ClientType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
