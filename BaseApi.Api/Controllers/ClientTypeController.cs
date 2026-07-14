using BaseApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Api.Controllers
{
    [ApiController]
    [Route("api/client-types")]
    public class ClientTypeController : ControllerBase
    {
        private readonly IClientTypeService _clientTypeService;

        public ClientTypeController(IClientTypeService clientTypeService)
        {
            _clientTypeService = clientTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _clientTypeService.GetAllAsync(cancellationToken);
            return Ok(result);
        }
    }
}
