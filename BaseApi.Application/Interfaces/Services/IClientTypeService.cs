using BaseApi.Application.DTOs.ClientTypes;
using BaseApi.Application.Wrapper;

namespace BaseApi.Application.Interfaces.Services
{
    public interface IClientTypeService
    {
        Task<ApiResponse<List<ClientTypeResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
