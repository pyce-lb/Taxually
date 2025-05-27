using FluentAssertions;
using Taxually.TechnicalTest.Infrastructure;

namespace Taxually.TechnicalTest.Tests.InMemory.Infrastructure;
public sealed class VatRegistrationCsvSerializerTests : VatRegistrationTests
{
    private readonly VatRegistrationCsvSerializer _csvSerializer = new VatRegistrationCsvSerializer();

    [Fact]
    public void Serialize_Success()
    {
        // Arrange
        var input = CreateVatRegistrationCommand();

        // Act
        string result = _csvSerializer.Serialize(input);

        // Assert
        string expected = $"""
            CompanyName,CompanyId
            {input.CompanyName},{input.CompanyId}
            """;
        result.Should().BeEquivalentTo(expected);
    }
}
