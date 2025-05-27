namespace Taxually.TechnicalTest.Application;

public interface IXmlSerializer<in T> : ISerializer<T> where T : notnull
{
}
