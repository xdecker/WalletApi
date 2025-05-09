using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Entities;

namespace Wallet.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
