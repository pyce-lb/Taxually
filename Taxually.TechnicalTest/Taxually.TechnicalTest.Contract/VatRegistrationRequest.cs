using System.ComponentModel.DataAnnotations;

namespace Taxually.TechnicalTest.Contract;

public record VatRegistrationRequest
{
    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    public string CompanyId { get; set; } = string.Empty;

    [Required]
    [EnumDataType(typeof(Country), ErrorMessage = "Country not supported.")]
    public Country? Country { get; set; }
}
