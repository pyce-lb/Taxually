using FluentAssertions;
using Taxually.TechnicalTest.Domain;

namespace Taxually.TechnicalTest.Tests.InMemory.Domain;

public sealed class CompanyNameTests
{
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Ctor_Invalid_Fail(string name)
    {
        // Act
        Action action = () => _ = new CompanyName(name);

        // Assert
        action.Should().ThrowExactly<ArgumentException>().WithParameterName(nameof(name));
    }

    [Theory]
    [InlineData("company-name")]
    [InlineData("Taxually")]
    public void Ctor_Valid_Success(string name)
    {
        // Act
        var companyId = new CompanyName(name);

        // Assert
        companyId.Name.Should().BeEquivalentTo(name);
    }

    [Theory]
    [InlineData("company-name")]
    [InlineData("Taxually")]
    public void ToString_Id(string name)
    {
        // Arrange
        var companyId = new CompanyName(name);

        // Act
        var result = companyId.ToString();

        // Assert
        result.Should().BeEquivalentTo(name);
    }
}
