using FluentAssertions;
using Taxually.TechnicalTest.Domain;

namespace Taxually.TechnicalTest.Tests.InMemory.Domain;

public sealed class CompanyIdTests
{
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Ctor_Invalid_Fail(string id)
    {
        // Act
        Action action = () => _ = new CompanyId(id);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithParameterName(nameof(id));
    }

    [Theory]
    [InlineData("company-id")]
    [InlineData("company-id2")]
    public void Ctor_Valid_Success(string id)
    {
        // Act
        var companyId = new CompanyId(id);

        // Assert
        companyId.Id.Should().BeEquivalentTo(id);
    }

    [Theory]
    [InlineData("company-id")]
    [InlineData("company-id2")]
    public void ToString_Id(string id)
    {
        // Arrange
        var companyId = new CompanyId(id);

        // Act
        var result = companyId.ToString();

        // Assert
        result.Should().BeEquivalentTo(id);
    }
}
