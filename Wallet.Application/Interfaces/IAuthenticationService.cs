using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(string username, string password, string email, string documentId);
        Task<string> LoginAsync(string username, string password);
    }
}
