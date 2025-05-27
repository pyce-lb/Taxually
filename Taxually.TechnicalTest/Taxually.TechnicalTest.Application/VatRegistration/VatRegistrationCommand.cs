using System.Diagnostics.CodeAnalysis;
using Taxually.TechnicalTest.Domain;

namespace Taxually.TechnicalTest.Application.VatRegistration;

public sealed record VatRegistrationCommand : ICommand
{
    public required CompanyName CompanyName { get; init; }

    public required CompanyId CompanyId { get; init; }

    private VatRegistrationCommand() { }

    [SetsRequiredMembers]
    public VatRegistrationCommand(CompanyName companyName, CompanyId companyId)
    {
        CompanyName = companyName;
        CompanyId = companyId;
    }
}
