namespace Taxually.TechnicalTest.Application;

public interface ISerializer
{
    public const string CsvKey = "csv";
    public const string XmlKey = "xml";
}

public interface ISerializer<in T> : ISerializer where T : notnull
{
    string Serialize(T obj);
}
