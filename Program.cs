using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace DesignPatterns
{
    public class Person : ICloneable
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public object Clone()
        {
            // shallow copy
            return new Person(Names, Address.Clone() as Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(", ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
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
            var ayse = ali.Clone() as Person;
            ayse.Names[0] = "Ayse";

            WriteLine(ali);
            WriteLine(ayse);
        }
    }
}
