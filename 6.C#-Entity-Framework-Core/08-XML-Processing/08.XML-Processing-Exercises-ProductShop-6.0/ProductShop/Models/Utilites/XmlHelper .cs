using System.Xml.Serialization;

namespace ProductShop.Models.Utilites;

public class XmlHelper
{
    public static T? Deserialize<T>(string inputXml, string rootAttributeName)
    {
        XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootAttributeName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T?), xmlRootAttribute);

        using StringReader stringReader = new StringReader(inputXml);
        T? deserializedObject = (T?)xmlSerializer.Deserialize(stringReader);

        return deserializedObject;
    }

    public static T? Deserialize<T>(Stream inputStream, string rootAttributeName)
    {
        XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootAttributeName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T?), xmlRootAttribute);

        T? deserializedObject = (T?)xmlSerializer.Deserialize(inputStream);

        return deserializedObject;
    }
}