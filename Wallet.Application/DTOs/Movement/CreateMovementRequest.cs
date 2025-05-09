using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Enums;

namespace Wallet.Application.DTOs.Movement
{
    public class CreateMovementRequest
    {
        [Required]
        public int WalletId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Amount { get; set; }

        [Required]
        [EnumDataType(typeof(MovementType), ErrorMessage = "Tipo inválido.")]
        public MovementType Type { get; set; }
    }
}
