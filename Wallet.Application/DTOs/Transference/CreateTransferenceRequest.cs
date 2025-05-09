using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.DTOs.Transference
{
    public class CreateTransferenceRequest
    {
        [Required]
        public int FromWalletId { get; set; }

        [Required]
        public int ToWalletId { get; set; }

        public string CreatedBy { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Amount { get; set; }
    }
}
