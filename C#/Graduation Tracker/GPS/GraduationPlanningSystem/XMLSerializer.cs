using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GraduationPlanningSystem.Data_Objects;
using System.Xml.Serialization;
using System.IO;

namespace GraduationPlanningSystem
{
    /// <summary>
    /// Used for converting hard to soft objects
    /// </summary>
    static public class XMLSerializer
    {
        /// <summary>
        /// Convert object to XML
        /// </summary>
        /// <param name="degree">degree to serializze</param>
        /// <param name="file">file location</param>
        static public void SerializeDegreeToXML(Degree degree, string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Degree));
            TextWriter textWriter = new StreamWriter(file);
            serializer.Serialize(textWriter, degree);
            textWriter.Close();
        }

        /// <summary>
        /// File to deserialize
        /// </summary>
        /// <param name="file"></param>
        /// <returns>deserialized degree</returns>
        static public Degree DeserializeXMLToDegree(string file)
        {
            if (file != "")
            {
                Degree result = new Degree();
                XmlSerializer deserializer = new XmlSerializer(typeof(Degree));
                TextReader textReader = new StreamReader(file);
                result = (Degree)deserializer.Deserialize(textReader);
                textReader.Close();
                return result;
            }
            return null;
        }
    }
}
