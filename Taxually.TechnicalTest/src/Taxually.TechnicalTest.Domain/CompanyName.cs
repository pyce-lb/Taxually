using System.Diagnostics.CodeAnalysis;

namespace Taxually.TechnicalTest.Domain;

public record CompanyName
{
    private CompanyName() { }

    [SetsRequiredMembers]
    public CompanyName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }

    public required string Name { get; init; }

    public override string ToString() => Name;
}
