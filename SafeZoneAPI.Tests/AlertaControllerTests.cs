using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc.Testing;
using SafeZoneAPI.Helpers;
using Microsoft.Extensions.DependencyInjection;
using SafeZoneAPI.Models;
using System.Net.Http.Json;
using SafeZoneAPI;

public class AlertaControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AlertaControllerTests(WebApplicationFactory<Program> factory)
    {
        var mockRabbit = new Mock<IRabbitMQPublisher>();
        mockRabbit.Setup(p => p.PublicarMensagem(It.IsAny<string>()));

        var customizedFactory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(_ => mockRabbit.Object);
            });
        });

        _client = customizedFactory.CreateClient();
    }

    [Fact]
    public async Task PostAlerta_DeveRetornarStatusCreated()
    {
        var alerta = new Alerta
        {
            DataEmissao = DateTime.UtcNow,
            Mensagem = "Teste de alerta",
            Nivel = "Alto",
            RegiaoRiscoId = 1
        };

        var response = await _client.PostAsJsonAsync("/api/Alerta", alerta);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        await Task.CompletedTask;
    }
}
