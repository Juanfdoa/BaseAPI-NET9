using BaseApi.Application.DTOs.Clients;
using BaseApi.Application.Interfaces.Services;
using BaseApi.Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Get all Clients with optional filtering and pagination
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ClientResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]ClientFilterDto filter, [FromQuery]Pagination pagination)
        {
            var response = await _clientService.GetAllAsync(filter,pagination);
            return Ok(response);
        }

        /// <summary>
        /// Get client by id
        /// </summary>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse<ClientDetailedResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _clientService.GetByIdAsync(id);
            return Ok(response);
        }

        /// <summary>
        /// Create client
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ClientDetailedResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ClientRequestDto request)
        {
            var client = await _clientService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = client.Data!.Id }, client);
        }

        /// <summary>
        /// Update client
        /// </summary>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClientRequestDto request)
        {
            await _clientService.UpdateAsync(id, request);
            return NoContent();
        }

        /// <summary>
        /// Delete client
        /// </summary>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _clientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
