using Riok.Mapperly.Abstractions;
using Taxually.TechnicalTest.Application.VatRegistration;
using Taxually.TechnicalTest.Contract;

namespace Taxually.TechnicalTest.Mappings;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
public partial class VatRegistrationRequestMapper
{
    [MapperIgnoreSource(nameof(VatRegistrationRequest.Country))]
    public partial VatRegistrationCommand Map(VatRegistrationRequest request);

    [MapperIgnoreTargetValue(Domain.Country.None)]
    public partial Domain.Country Map(Contract.Country? country);
}
