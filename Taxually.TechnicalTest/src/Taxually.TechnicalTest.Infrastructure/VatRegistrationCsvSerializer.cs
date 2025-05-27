using System.Text;
using Taxually.TechnicalTest.Application;
using Taxually.TechnicalTest.Application.VatRegistration;

namespace Taxually.TechnicalTest.Infrastructure;

public class VatRegistrationCsvSerializer : ICsvSerializer<VatRegistrationCommand>
{
    private const string Header = $"{nameof(VatRegistrationCommand.CompanyName)},{nameof(VatRegistrationCommand.CompanyId)}";

    public string Serialize(VatRegistrationCommand command)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine(Header);
        csvBuilder.Append($"{command.CompanyName},{command.CompanyId}");
        var csv = csvBuilder.ToString();
        return csv;
    }
}