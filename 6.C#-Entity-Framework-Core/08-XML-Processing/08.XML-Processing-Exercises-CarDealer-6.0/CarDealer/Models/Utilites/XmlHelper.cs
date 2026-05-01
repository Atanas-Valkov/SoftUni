using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.Models.Utilites
{
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

        public static string Serialize<T>(T objectToSerialize, string rootAttributeName, IDictionary<string, string>? namespaces = null)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            if (namespaces == null)
            {
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            }
            else
            {
                foreach (KeyValuePair<string, string> nsKvp in namespaces)
                {
                    xmlSerializerNamespaces.Add(nsKvp.Key, nsKvp.Value);
                }
            }

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootAttributeName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRootAttribute);

            using StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, objectToSerialize, xmlSerializerNamespaces);
            return sb.ToString().TrimEnd();
        }

        public static void Serialize<T>(T objectToSerialize, string rootAttributeName, Stream outputStream, IDictionary<string, string>? namespaces = null)
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            if (namespaces == null)
            {
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            }
            else
            {
                foreach (KeyValuePair<string, string> nsKvp in namespaces)
                {
                    xmlSerializerNamespaces.Add(nsKvp.Key, nsKvp.Value);
                }
            }

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootAttributeName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRootAttribute);

            xmlSerializer.Serialize(outputStream, objectToSerialize, xmlSerializerNamespaces);
        }
    }
}
