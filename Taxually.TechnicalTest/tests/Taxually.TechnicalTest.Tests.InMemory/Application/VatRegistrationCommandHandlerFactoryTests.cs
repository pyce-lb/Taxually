using System.Diagnostics;
using FluentAssertions;
using Moq;
using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Domain;

namespace Taxually.TechnicalTest.Tests.InMemory.Application;

public sealed class VatRegistrationCommandHandlerFactoryTests
{
    private readonly VatRegistrationCommandHandlerFactory _commandHandlerFactory = new VatRegistrationCommandHandlerFactory(
        Mock.Of<ITaxuallyHttpClient>(),
        Mock.Of<ITaxuallyQueueClient>(),
        Mock.Of<ICsvSerializer<VatRegistrationCommand>>(),
        Mock.Of<IXmlSerializer<VatRegistrationCommand>>());

    [Theory]
    [InlineData(Country.GreatBritain, typeof(ApiVatRegistrationCommandHandler))]
    [InlineData(Country.France, typeof(CsvVatRegistrationCommandHandler))]
    [InlineData(Country.Germany, typeof(XmlVatRegistrationCommandHandler))]
    public void Create_ValidCountry_Handler(Country country, Type expectation)
    {
        // Act
        var result = _commandHandlerFactory.Create(country);

        // Assert
        result.Should().BeOfType(expectation);
    }

    [Theory]
    [InlineData(Country.None)]
    public void Create_InvalidCountry_ThrowUnreachableException(Country country)
    {
        // Act
        Action action = () => _commandHandlerFactory.Create(country);

        // Assert
        action.Should().ThrowExactly<UnreachableException>();
    }
}
