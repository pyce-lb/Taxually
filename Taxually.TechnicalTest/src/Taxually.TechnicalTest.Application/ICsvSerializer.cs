namespace Taxually.TechnicalTest.Application;

public interface ICsvSerializer<in T> : ISerializer<T> where T : notnull
{
}
