using BaseApi.Application.DTOs.Clients;
using BaseApi.Application.Exceptions;
using BaseApi.Application.Interfaces.Repositories;
using BaseApi.Application.Interfaces.Services;
using BaseApi.Application.Mapping;
using BaseApi.Application.Wrapper;
using static System.Net.WebRequestMethods;

namespace BaseApi.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientTypeRepository _clientTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository,
            IClientTypeRepository clientTypeRepository,
            IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _clientTypeRepository = clientTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<IEnumerable<ClientResponseDto>>> GetAllAsync(ClientFilterDto filter, Pagination pagination)
        {
            var result = await _clientRepository.GetFilteredAsync(filter,pagination);

            return new ApiResponse<IEnumerable<ClientResponseDto>>
            {
                Success = true,
                Data = result.Items.Select(ClientMapper.ToResponseDto),
                Pagination = new PaginationResponse
                {
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize,
                    TotalRecords = result.TotalRecords
                }
            };
        }

        public async Task<ApiResponse<ClientDetailedResponseDto?>> GetByIdAsync(Guid id)
        {
            var hotel = await _clientRepository.GetByIdWithIncludesAsync(id)
               ?? throw new NotFoundException("The requested resource was not found.");

            return new ApiResponse<ClientDetailedResponseDto?>
            {
                Data = ClientMapper.ToDetailedResponseDto(hotel)
            };
        }

        public async Task<ApiResponse<ClientDetailedResponseDto>> CreateAsync(ClientRequestDto request)
        {
            var type = await _clientTypeRepository.GetByIdAsync(request.ClientTypeId);

            if (type is null)
                throw new BadRequestException($"ClientType does not exist.");

            var client = ClientMapper.ToEntity(request);
            client = await _clientRepository.AddAsync(client);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<ClientDetailedResponseDto>
            {
                Data = ClientMapper.ToDetailedResponseDto(client)
            };
        }

        public async Task UpdateAsync(Guid id, ClientRequestDto request)
        {
            var client = await _clientRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("The requested resource was not found.");

            ClientMapper.UpdateEntity(request, client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("The requested resource was not found.");

            client.SoftDelete();
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
