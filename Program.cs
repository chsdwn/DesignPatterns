using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using static System.Console;

namespace DesignPatterns
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var stream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stream, self);
                stream.Position = 0;
                return (T)xmlSerializer.Deserialize(stream);
            }
        }
    }

    // needed for DeepCopy()
    [Serializable]
    public class Person
    {
        public string[] Names;
        public Address Address;

        // needed for DeepCopyXml()
        public Person()
        {
        }

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    [Serializable]
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var ali = new Person(new[] { "Ali", "Veli" }, new Address("A Street", 100));
            var ayse = ali.DeepCopy();
            ayse.Names[0] = "Ayse";
            ayse.Address.HouseNumber = 200;

            WriteLine(ali);
            WriteLine(ayse);
        }
    }
}
