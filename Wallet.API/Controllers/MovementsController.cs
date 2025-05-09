using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.DTOs.Movement;
using Wallet.Application.Interfaces;
using Wallet.Domain.Entities;

namespace Wallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementService _movementService;
        private readonly ILogger<MovementsController> _logger;

        public MovementsController(IMovementService movementService, ILogger<MovementsController> logger)
        {
            _movementService = movementService;
            _logger = logger;
        }

        [HttpGet("wallet/{walletId}")]
        public async Task<IActionResult> GetMovementsByWallet(int walletId)
        {
            try
            {
                var result = await _movementService.GetByWalletIdAsync(walletId);
                if (result == null || !result.Any())
                    return NotFound("No se encontraron movimientos para esta billetera.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"Error: {ex.Message}");
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateMovementRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var movement = new MovementHistory
                {
                    walletId = request.WalletId,
                    amount = request.Amount,
                    type = request.Type,
                    createdAt = DateTime.Now,
                    createdBy = User?.Identity?.Name ?? "SISTEMA"
                };

                var result = await _movementService.CreateAsync(movement);

                if (!result.Success)
                    return BadRequest(result.ErrorMessage);

                return Created("", result.Movement);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creando movimiento");
                return BadRequest(ex.Message);
            }
 
        }
    }
}
