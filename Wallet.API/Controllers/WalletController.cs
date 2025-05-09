using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallet.Application.DTOs.Wallet;
using Wallet.Application.Interfaces;
using Wallet.Application.Services;
using Wallet.Domain.Entities;

namespace Wallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly ILogger<WalletController> _logger;

        public WalletController(IWalletService walletService, ILogger<WalletController> logger)
        {
            _walletService = walletService;
            _logger = logger;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billetera>>> GetWallets()
        {
            var wallets = await _walletService.GetAllAsync();
            if (wallets == null || !wallets.Any())
            {
                return NotFound("No se encontraron billeteras");
            }

            return Ok(wallets);
        }

        // GET: api/wallets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Billetera>> GetWallet(int id)
        {
            var wallet = await _walletService.GetByIdAsync(id);
            if (wallet == null)
            {
                return NotFound($"Billeta con el ID {id} no fue encontrada.");
            }

            return Ok(wallet);
        }

        // POST: api/wallets
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Billetera>> CreateWallet([FromBody] CreateWalletRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var wallet = new Billetera
                {
                    name = request.Name,
                    isActive = true,
                    balance = request.InitialBalance,
                    documentId = request.documentId,
                    createdAt = DateTime.Now,
                    createdBy = User?.Identity?.Name ?? "SISTEMA"
                };

                var createdWallet = await _walletService.CreateAsync(wallet);
                return CreatedAtAction(nameof(GetWallet), new { id = createdWallet.id }, createdWallet);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error creando billetera");
                return BadRequest(ex.Message);
            }
            
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateWallet(long id, [FromBody] UpdateWalletRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var walletToUpdate = new Billetera
                {
                    id = id,
                    name = request.Name,
                    balance = request.Balance,
                    documentId = request.documentId,
                    updatedAt = DateTime.Now,
                    updatedBy = User?.Identity?.Name ?? "SISTEMA"
                };

                var updated = await _walletService.UpdateAsync(walletToUpdate);
                if (!updated)
                {
                    return NotFound($"Billetera con ID {id} no fue encontrada.");
                }

                return NoContent();

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error actualizando billetera");
                return BadRequest(ex.Message);
            }
            
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteWallet(long id)
        {
            var deleted = await _walletService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Billetera con ID {id} no fue encontrada.");
            }

            return NoContent();
        }
        
    }
}
