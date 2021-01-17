using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace RandomDataGenerator
{
    public static class Serializator
    {
        public static void Serialize<T>(string fileName, List<T> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, data);
            }
        }

        public static IList<T> Deserialize<T>(string fileName)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));

            TextReader reader = new StreamReader(fileName);

            object obj = deserializer.Deserialize(reader);

            reader.Close();

            return (List<T>)obj;
        }
    }
}
