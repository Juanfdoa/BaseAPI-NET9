using BaseApi.Application.Interfaces.Repositories;
using BaseApi.Domain.Entities;
using BaseApi.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Infrastructure.Repositories
{
    public class ClientTypeRepository : BaseRepository<ClientTypeTable>, IClientTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ClientTypeTable>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ClientTypes
               .Where(x => x.IsActive)
               .OrderBy(x => x.Name)
               .ToListAsync(cancellationToken);
        }
    }
}
