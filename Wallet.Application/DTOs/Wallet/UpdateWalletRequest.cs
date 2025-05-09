using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.DTOs.Wallet
{
    public class UpdateWalletRequest
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El saldo no puede ser negativo.")]
        public decimal Balance { get; set; }

        [Required]
        public string documentId { get; set; }
    }
}
