using System.Xml.Serialization;
using Taxually.TechnicalTest.Application;

namespace Taxually.TechnicalTest.Infrastructure;

public class XmlSerializer<T> : ISerializer<T> where T : notnull
{
    public string Serialize(T obj)
    {
        using var stringWriter = new StringWriter();
        var serializer = new XmlSerializer(obj.GetType());
        serializer.Serialize(stringWriter, obj);
        var xml = stringWriter.ToString();
        return xml;
    }
}
