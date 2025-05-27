namespace Taxually.TechnicalTest.Domain;

public sealed record CompanyId
{
    public CompanyId(string id) => Id = id;

    public string Id { get; }

    public override string ToString() => Id;
}
