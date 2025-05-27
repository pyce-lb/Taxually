using System.Diagnostics;
using Taxually.TechnicalTest.Domain;

namespace Taxually.TechnicalTest.Application.VatRegistration;

public sealed class VatRegistrationCommandHandlerFactory
{
    private const string ErrorMessage = "Country not supported.";

    private readonly ITaxuallyHttpClient _httpClient;
    private readonly ITaxuallyQueueClient _queueClient;
    private readonly ICsvSerializer<VatRegistrationCommand> _csvSerializer;
    private readonly IXmlSerializer<VatRegistrationCommand> _xmlSerializer;

    public VatRegistrationCommandHandlerFactory(
        ITaxuallyHttpClient httpClient,
        ITaxuallyQueueClient queueClient,
        ICsvSerializer<VatRegistrationCommand> csvSerializer,
        IXmlSerializer<VatRegistrationCommand> xmlSerializer)
    {
        _httpClient = httpClient;
        _queueClient = queueClient;
        _csvSerializer = csvSerializer;
        _xmlSerializer = xmlSerializer;
    }

    public ICommandHandler<VatRegistrationCommand> Create(Country country)
    {
        return country switch
        {
            Country.GreatBritain => new ApiVatRegistrationCommandHandler(_httpClient),
            Country.France => new CsvVatRegistrationCommandHandler(_queueClient, _csvSerializer),
            Country.Germany => new XmlVatRegistrationCommandHandler(_queueClient, _xmlSerializer),
            _ => throw new UnreachableException(ErrorMessage)
        };
    }
}
