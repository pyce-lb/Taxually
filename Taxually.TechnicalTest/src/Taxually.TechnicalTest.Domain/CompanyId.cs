using System.Diagnostics.CodeAnalysis;

namespace Taxually.TechnicalTest.Domain;

public record CompanyId
{
    private CompanyId() { }

    [SetsRequiredMembers]
    public CompanyId(string id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        Id = id;
    }

    public required string Id { get; init; }

    public override string ToString() => Id;
}
