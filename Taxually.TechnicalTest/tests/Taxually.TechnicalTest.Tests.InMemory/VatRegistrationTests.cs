using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Domain;

namespace Taxually.TechnicalTest.Tests.InMemory;

public abstract class VatRegistrationTests
{
    private readonly CompanyName _companyName = new CompanyName("Taxually");
    private readonly CompanyId _companyId = new CompanyId("company-id");

    public VatRegistrationCommand CreateVatRegistrationCommand() => new VatRegistrationCommand(_companyName, _companyId);
}
