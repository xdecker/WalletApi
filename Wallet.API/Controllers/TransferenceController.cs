using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.DTOs.Transference;
using Wallet.Application.Interfaces;

namespace Wallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenceController : ControllerBase
    {
        private readonly ITransferenceService _service;
        private readonly ILogger<TransferenceController> _logger;

        public TransferenceController(ITransferenceService service, ILogger<TransferenceController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateTransferenceRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _service.CreateAsync(request);
                if (!result.Success)
                    return BadRequest(new { error = result.ErrorMessage });

                return Ok(new { message = "Transferencia realizada con éxito." });
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creando transferencia");
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transfers = await _service.GetAllAsync();
            return Ok(transfers);
        }
    }
}
