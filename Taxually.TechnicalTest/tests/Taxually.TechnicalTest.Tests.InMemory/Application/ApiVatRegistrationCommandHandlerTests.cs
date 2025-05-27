using Moq;
using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;

namespace Taxually.TechnicalTest.Tests.InMemory.Application;

public sealed class ApiVatRegistrationCommandHandlerTests : VatRegistrationTests
{
    private static readonly Mock<ITaxuallyHttpClient> _httpClientMock = new Mock<ITaxuallyHttpClient>();
    private readonly ApiVatRegistrationCommandHandler _commandHandler = new ApiVatRegistrationCommandHandler(_httpClientMock.Object);

    [Fact]
    public async Task HandleAsync_Success()
    {
        // Arrange
        var command = CreateVatRegistrationCommand();

        // Act
        await _commandHandler.HandleAsync(command);

        // Assert
        _httpClientMock.Verify(httpClient => httpClient.PostAsync(ApiVatRegistrationCommandHandler.Url, command, It.IsAny<CancellationToken>()));
    }
}
