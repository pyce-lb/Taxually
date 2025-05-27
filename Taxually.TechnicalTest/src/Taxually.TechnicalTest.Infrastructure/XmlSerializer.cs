using System.Xml.Serialization;
using Taxually.TechnicalTest.Application;

namespace Taxually.TechnicalTest.Infrastructure;

public class XmlSerializer<T> : IXmlSerializer<T> where T : notnull
{
    public string Serialize(T obj)
    {
        using var stringWriter = new StringWriter();
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stringWriter, obj);
        var xml = stringWriter.ToString();
        return xml;
    }
}
