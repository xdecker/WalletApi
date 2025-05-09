using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Services;
using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;

namespace Wallet.Test
{
    public class WalletServiceTest
    {
        [Fact]
        public async Task GetByIdAsync_ShouldReturnWallet_WhenExists()
        {
            // Arrange
            var fakeWallet = new Billetera { id = 1, name = "Mi billetera" };

            var repoMock = new Mock<IWalletRepository>();
            repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(fakeWallet);

            var service = new WalletService(repoMock.Object);

            // Act
            var result = await service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.id);
            Assert.Equal("Mi billetera", result.name);
        }
    }
}
