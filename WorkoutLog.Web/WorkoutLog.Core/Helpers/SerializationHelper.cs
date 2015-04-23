using System;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace WorkoutLog.Core.Helpers
{
    public static class SerializationHelper
    {
        private static readonly Object ObjToLock = new object();

        public static void Serialize<T>(string filename, T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            lock (ObjToLock)
            {
                try
                {
                    var stream = File.Create(filename);
                    serializer.Serialize(stream, obj);
                    stream.Dispose();
                }
                catch (Exception ex)
                {  }
            }
        }

        public static string SerializeToString(object obj)
        {
            var serializer = new XmlSerializer(obj.GetType());

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);

                return writer.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            var xmlReader = new XmlTextReader(new StringReader(xml));
            return Deserialize<T>(xmlReader);
        }

        public static T Deserialize<T>(XmlReader xmlReader)
        {
            var serializer = new XmlSerializer(typeof(T));
            var ret = (T)serializer.Deserialize(xmlReader);
            xmlReader.Close();
            return ret;
        }

        public static T Deserialize<T>(Stream fileStream)
        {
            var serializer = new XmlSerializer(typeof(T));
            XmlReader reader = new XmlTextReader(fileStream);
            var ret = (T)serializer.Deserialize(reader);
            fileStream.Close();
            return ret;
        }
    }
}
