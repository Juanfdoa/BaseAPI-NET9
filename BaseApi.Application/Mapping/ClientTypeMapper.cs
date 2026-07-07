using BaseApi.Application.DTOs.ClientTypes;
using BaseApi.Domain.Entities;

namespace BaseApi.Application.Mapping
{
    public static class ClientTypeMapper
    {
        public static ClientTypeResponseDto MapToResponse(ClientTypeTable entity)
        {
            return new ClientTypeResponseDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
