using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc.Testing;


namespace SafeZoneAPI.Tests
{
    public class RegiaoRiscoControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public RegiaoRiscoControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/api/RegiaoRisco");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
