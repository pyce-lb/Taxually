namespace Taxually.TechnicalTest.Contract;

public class VatRegistrationRequest
{
    public string CompanyName { get; set; }
    public string CompanyId { get; set; }
    public Country Country { get; set; }
}
