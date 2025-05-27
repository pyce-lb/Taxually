namespace Taxually.TechnicalTest.Domain;

public sealed record CompanyName
{
    public CompanyName(string name) => Name = name;

    public string Name { get; }

    public override string ToString() => Name;
}
