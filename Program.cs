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
        public string StreetAddress, Postcode, City;
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, "
                + $"{nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, "
                + $"{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, "
                + $"{nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder // facade
    {
        // reference
        protected Person _person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(_person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(_person);

        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder._person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            _person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            _person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            _person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            _person.AnnualIncome = amount;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            _person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            _person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            _person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            _person.City = city;
            return this;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var personBuilder = new PersonBuilder();
            Person person = personBuilder
                .Works
                    .At("Company")
                    .AsA("Developer")
                    .Earning(1000)
                .Lives
                    .At("A Street")
                    .WithPostcode("1")
                    .In("B City");
            WriteLine(person);
        }
    }
}
