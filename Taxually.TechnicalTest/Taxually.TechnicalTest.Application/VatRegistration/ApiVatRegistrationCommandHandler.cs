namespace Taxually.TechnicalTest.Application.VatRegistration;

public sealed class ApiVatRegistrationCommandHandler : ICommandHandler<VatRegistrationCommand>
{
    private const string Url = "https://api.uktax.gov.uk";

    private readonly ITaxuallyHttpClient _httpClient;

    public ApiVatRegistrationCommandHandler(ITaxuallyHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task HandleAsync(VatRegistrationCommand command, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsync(Url, command, cancellationToken);
    }
}
