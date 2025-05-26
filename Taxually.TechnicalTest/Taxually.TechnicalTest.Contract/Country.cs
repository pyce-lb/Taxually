using System.Text.Json.Serialization;

namespace Taxually.TechnicalTest.Contract;

[JsonConverter(typeof(JsonStringEnumConverter<Country>))]
public enum Country
{
    [JsonStringEnumMemberName("GB")]
    GreatBritain,
    [JsonStringEnumMemberName("FR")]
    France,
    [JsonStringEnumMemberName("DE")]
    Germany
}
