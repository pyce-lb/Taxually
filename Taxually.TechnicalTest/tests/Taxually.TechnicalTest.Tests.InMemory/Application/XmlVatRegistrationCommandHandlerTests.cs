using Moq;
using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;

namespace Taxually.TechnicalTest.Tests.InMemory.Application;

public sealed class XmlVatRegistrationCommandHandlerTests : VatRegistrationTests
{
    private static readonly Mock<ITaxuallyQueueClient> _queueClientMock = new Mock<ITaxuallyQueueClient>();
    private static readonly Mock<IXmlSerializer<VatRegistrationCommand>> _serializerMock = new Mock<IXmlSerializer<VatRegistrationCommand>>();

    private readonly XmlVatRegistrationCommandHandler _commandHandler = new XmlVatRegistrationCommandHandler(
        _queueClientMock.Object,
        _serializerMock.Object);

    [Fact]
    public async Task HandleAsync_Success()
    {
        // Arrange
        var command = CreateVatRegistrationCommand();
        var xmlMock = command.ToString();
        _serializerMock
            .Setup(serializer => serializer.Serialize(command))
            .Returns(xmlMock);


        // Act
        await _commandHandler.HandleAsync(command);

        // Assert
        _queueClientMock.Verify(queueClientMock => queueClientMock.EnqueueAsync(
            XmlVatRegistrationCommandHandler.QueueName,
            xmlMock,
            It.IsAny<CancellationToken>()));
    }
}
