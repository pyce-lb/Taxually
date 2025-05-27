using FluentAssertions;
using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Domain;
using Taxually.TechnicalTest.Infrastructure;

namespace Taxually.TechnicalTest.Tests.InMemory.Infrastructure;

public sealed class XmlSerializerTests : VatRegistrationTests
{
    private readonly XmlSerializer<VatRegistrationCommand> _xmlSerializer = new XmlSerializer<VatRegistrationCommand>();

    [Fact]
    public void Serialize_Success()
    {
        // Arrange
        var input = CreateVatRegistrationCommand();

        // Act
        string result = _xmlSerializer.Serialize(input);

        // Assert
        var expected = """
            <?xml version="1.0" encoding="utf-16"?>
            <VatRegistrationCommand xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
              <CompanyName>
                <Name>Taxually</Name>
              </CompanyName>
              <CompanyId>
                <Id>company-id</Id>
              </CompanyId>
            </VatRegistrationCommand>
            """;
        result.Should().BeEquivalentTo(expected);
    }
}
