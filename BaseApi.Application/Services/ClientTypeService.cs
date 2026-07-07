using BaseApi.Application.DTOs.ClientTypes;
using BaseApi.Application.Interfaces.Repositories;
using BaseApi.Application.Interfaces.Services;
using BaseApi.Application.Mapping;
using BaseApi.Application.Wrapper;

namespace BaseApi.Application.Services
{
    public class ClientTypeService : IClientTypeService
    {
        private readonly IClientTypeRepository _clientTypeRepository;

        public ClientTypeService(IClientTypeRepository clientTypeRepository)
        {
            _clientTypeRepository = clientTypeRepository;
        }

        public async Task<ApiResponse<List<ClientTypeResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var clientTypes = await _clientTypeRepository.GetAllAsync(cancellationToken);

            return new ApiResponse<List<ClientTypeResponseDto>>
            {
                Data = clientTypes
                    .Select(ClientTypeMapper.MapToResponse)
                    .ToList(),

                Pagination = new PaginationResponse
                {
                    TotalRecords = clientTypes.Count
                }
            };
        }
    }
}
