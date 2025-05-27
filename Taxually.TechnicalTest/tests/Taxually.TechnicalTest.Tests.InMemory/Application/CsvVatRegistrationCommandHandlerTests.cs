using System.Text;
using Moq;
using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;

namespace Taxually.TechnicalTest.Tests.InMemory.Application;

public sealed class CsvVatRegistrationCommandHandlerTests : VatRegistrationTests
{
    private static readonly Mock<ITaxuallyQueueClient> _queueClientMock = new Mock<ITaxuallyQueueClient>();
    private static readonly Mock<ICsvSerializer<VatRegistrationCommand>> _serializerMock = new Mock<ICsvSerializer<VatRegistrationCommand>>();

    private readonly CsvVatRegistrationCommandHandler _commandHandler = new CsvVatRegistrationCommandHandler(
        _queueClientMock.Object,
        _serializerMock.Object);

    [Fact]
    public async Task HandleAsync_Success()
    {
        // Arrange
        var command = CreateVatRegistrationCommand();
        var csvMock = command.ToString();
        _serializerMock
            .Setup(serializer => serializer.Serialize(command))
            .Returns(csvMock);


        // Act
        await _commandHandler.HandleAsync(command);

        // Assert
        byte[] payload = Encoding.UTF8.GetBytes(csvMock);
        _queueClientMock.Verify(queueClientMock => queueClientMock.EnqueueAsync(
            CsvVatRegistrationCommandHandler.QueueName,
            payload,
            It.IsAny<CancellationToken>()));
    }
}
