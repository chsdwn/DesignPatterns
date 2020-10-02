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
    public class Person
    {
        public string Name, Position;
    }

    public class PersonBuilder
    {
        public readonly List<Action<Person>> Actions = new List<Action<Person>>();

        public PersonBuilder Called(string name)
        {
            Actions.Add(p => p.Name = name);
            return this;
        }

        public Person Build()
        {
            var person = new Person();
            Actions.ForEach(a => a(person));
            return person;
        }
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAsA(this PersonBuilder builder, string position)
        {
            builder.Actions.Add(p => p.Position = position);
            return builder;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var personBuilder = new PersonBuilder();
            var person = personBuilder
                .Called("Hulusi")
                .WorksAsA("Developer")
                .Build();
            WriteLine(person);
        }
    }
}
