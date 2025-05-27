namespace Taxually.TechnicalTest.Application.VatRegistration;

public sealed class ApiVatRegistrationCommandHandler : ICommandHandler<VatRegistrationCommand>
{
    public const string Url = "https://api.uktax.gov.uk";

    private readonly ITaxuallyHttpClient _httpClient;

    public ApiVatRegistrationCommandHandler(ITaxuallyHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async ValueTask HandleAsync(VatRegistrationCommand command, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsync(Url, command, cancellationToken);
    }
}
