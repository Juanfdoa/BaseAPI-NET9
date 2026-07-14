using BaseApi.Application.DTOs.Clients;
using BaseApi.Domain.Entities;

namespace BaseApi.Application.Mapping
{
    public static class ClientMapper
    {
        public static ClientResponseDto ToResponseDto(Client entity)
        {
            return new ClientResponseDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                LegalName = entity.LegalName,
                ClientType = entity.ClientType.Name,
                Email = entity.Email,
                Phone = entity.Phone
            };
        }

        public static ClientDetailedResponseDto ToDetailedResponseDto(Client entity)
        {
            return new ClientDetailedResponseDto
            {
                Id = entity.Id,
                Code = entity.Code,
                Name = entity.Name,
                LegalName = entity.LegalName,
                TaxId = entity.TaxId,
                ClientType = entity.ClientType.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Website = entity.Website,
                Address = entity.Address,
                ContactName = entity.ContactName,
                ContactEmail = entity.ContactEmail,
                ContactPhone = entity.ContactPhone,
                City = entity.City,
                Region = entity.Region,
                Country = entity.Country,
                PostalCode = entity.PostalCode,
                Notes = entity.Notes,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static Client ToEntity(ClientRequestDto request)
        {
            return new Client
            {
                Code = request.Code,
                Name = request.Name,
                LegalName = request.LegalName,
                TaxId = request.TaxId,
                ClientTypeId = request.ClientTypeId,
                Email = request.Email,
                Phone = request.Phone,
                Website = request.Website,
                Address = request.Address,
                ContactName = request.ContactName,
                ContactEmail = request.ContactEmail,
                ContactPhone = request.ContactPhone,
                City = request.City,
                Region = request.Region,
                Country = request.Country,
                PostalCode = request.PostalCode,
                Notes = request.Notes
            };
        }

        public static void UpdateEntity(ClientRequestDto request, Client client)
        {
            client.Code = request.Code;
            client.Name = request.Name;
            client.LegalName = request.LegalName;
            client.TaxId = request.TaxId;
            client.ClientTypeId = request.ClientTypeId;
            client.Email = request.Email;
            client.Phone = request.Phone;
            client.Website = request.Website;
            client.Address = request.Address;
            client.ContactName = request.ContactName;
            client.ContactEmail = request.ContactEmail;
            client.ContactPhone = request.ContactPhone;
            client.City = request.City;
            client.Region = request.Region;
            client.Country = request.Country;
            client.PostalCode = request.PostalCode;
            client.Notes = request.Notes;
        }
    }
}
