using FluentAssertions;
using System.Net.Http.Json;
using System.Net;
using Wallet.Application.DTOs.Wallet;
using Wallet.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Wallet.Test
{
    public class WalletTests : IClassFixture<WebApplicationFactory<Program>>
    {
        //private readonly HttpClient _client;

        //public WalletTests(CustomWebApplicationFactory factory)
        //{
        //    _client = factory.CreateClient();
        //}

        //[Fact]
        //public async Task GetAllWallets_ShouldReturn200Or404()
        //{
        //    var response = await _client.GetAsync("/api/wallet");

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        var wallets = await response.Content.ReadFromJsonAsync<List<Billetera>>();
        //        wallets.Should().NotBeNull();
        //    }
        //    else
        //    {
        //        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //    }
        //}

        //[Fact]
        //public async Task CreateWallet_ThenGetById_ShouldReturnSameWallet()
        //{
        //    var createRequest = new CreateWalletRequest
        //    {
        //        Name = "Prueba Test",
        //        InitialBalance = 1000,
        //        documentId = "1234567890"
        //    };

        //    var createResponse = await _client.PostAsJsonAsync("/api/wallet", createRequest);
        //    createResponse.EnsureSuccessStatusCode();

        //    var createdWallet = await createResponse.Content.ReadFromJsonAsync<Billetera>();
        //    createdWallet.Should().NotBeNull();
        //    createdWallet!.name.Should().Be("Prueba Test");

        //    var getResponse = await _client.GetAsync($"/api/wallet/{createdWallet.id}");
        //    getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        //    var walletFromGet = await getResponse.Content.ReadFromJsonAsync<Billetera>();
        //    walletFromGet!.name.Should().Be("Prueba Test");
        //}

        //[Fact]
        //public async Task UpdateWallet_ShouldModifyWallet()
        //{
            
        //    var createRequest = new CreateWalletRequest
        //    {
        //        Name = "Original",
        //        InitialBalance = 500,
        //        documentId = "87654321"
        //    };

        //    var createResponse = await _client.PostAsJsonAsync("/api/wallet", createRequest);
        //    var wallet = await createResponse.Content.ReadFromJsonAsync<Billetera>();

            
        //    var updateRequest = new UpdateWalletRequest
        //    {
        //        Name = "Actualizada",
        //        Balance = 999,
        //        documentId = "87654321"
        //    };

        //    var updateResponse = await _client.PutAsJsonAsync($"/api/wallet/{wallet!.id}", updateRequest);
        //    updateResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            
        //    var getResponse = await _client.GetAsync($"/api/wallet/{wallet.id}");
        //    var updatedWallet = await getResponse.Content.ReadFromJsonAsync<Billetera>();
        //    updatedWallet!.name.Should().Be("Actualizada");
        //    updatedWallet.balance.Should().Be(999);
        //}

        //[Fact]
        //public async Task DeleteWallet_ShouldRemoveWallet()
        //{
        //    var createRequest = new CreateWalletRequest
        //    {
        //        Name = "Borrar",
        //        InitialBalance = 100,
        //        documentId = "00000001"
        //    };

        //    var createResponse = await _client.PostAsJsonAsync("/api/wallet", createRequest);
        //    var wallet = await createResponse.Content.ReadFromJsonAsync<Billetera>();

        //    var deleteResponse = await _client.DeleteAsync($"/api/wallet/{wallet!.id}");
        //    deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

        //    var getResponse = await _client.GetAsync($"/api/wallet/{wallet.id}");
        //    getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        //}
    }
}