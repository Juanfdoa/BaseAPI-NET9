using BaseApi.Application.DTOs.Clients;
using BaseApi.Application.Wrapper;

namespace BaseApi.Application.Interfaces.Services
{
    public interface IClientService
    {
        Task<ApiResponse<IEnumerable<ClientResponseDto>>> GetAllAsync(ClientFilterDto filter, Pagination pagination);
        Task<ApiResponse<ClientDetailedResponseDto?>> GetByIdAsync(Guid id);
        Task<ApiResponse<ClientDetailedResponseDto>> CreateAsync(ClientRequestDto request);
        Task UpdateAsync(Guid id, ClientRequestDto request);
        Task DeleteAsync(Guid id);
    }
}
