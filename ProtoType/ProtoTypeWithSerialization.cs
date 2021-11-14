using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProtoType
{
    public static class ExtentionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            Object Copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)Copy;
        }

        public static T DeepCopyXML<T>(this T self)
        {
            using(var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }


   // [Serializable]
    public class Person4
    {
        public string[] Names;
        public Address4 Address;

        public Person4()
        {

        }
        public Person4(string[] names, Address4 address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"Name is : {string.Join(' ', Names)}, and Address is {Address}";
        }

    }

   // [Serializable]

    public class Address4
    {
        public string StreetName;
        public int HouseNumber;
        public Address4()
        {
        }

        public Address4(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }


        public override string ToString()
        {
            return $"StreetName: {StreetName}, HouseNumber: {HouseNumber}";
        }
    }

}
