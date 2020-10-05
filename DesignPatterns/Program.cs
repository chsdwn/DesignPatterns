using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using MoreLinq;
using static System.Console;

namespace DesignPatterns
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;
        private static int _instanceCount;
        public static int Count => _instanceCount;

        private SingletonDatabase()
        {
            ++_instanceCount;
            WriteLine("Initializing database...");

            _capitals = new Dictionary<string, int>
            {
                { "Tokyo", 33200000 },
                { "New York", 17800000 },
                { "Sao Paulo", 17700000 },
                { "Seoul", 17500000 },
                { "Mexico City", 17400000 },
                { "Osaka", 16425000 },
                { "Manila", 14750000 },
                { "Mumbai", 14350000 },
                { "Delhi", 14300000 },
                { "Jakarta", 14250000 }
            };
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        private static Lazy<SingletonDatabase> _instance =
            new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => _instance.Value;
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);

            return result;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}
