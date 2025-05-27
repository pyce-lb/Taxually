namespace Taxually.TechnicalTest.Application;

public interface ISerializer<in T> where T : notnull
{
    string Serialize(T obj);
}
