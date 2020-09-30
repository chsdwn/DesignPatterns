using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using static System.Console;

namespace DesignPatterns
{
    public enum Relationship
    {
        Parent, Child, Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    #region low-level
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> _relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add((child, Relationship.Child, parent));
        }

        // public List<(Person, Relationship, Person)> Relations => relations;

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var relation in _relations.Where(r => r.Item1.Name == name && r.Item2 == Relationship.Parent))
                yield return relation.Item3;
        }
    }
    #endregion

    public class Research
    {
        // public Research(Relationships relationships)
        // {
        //     var relations = relationships.Relations;
        //     foreach (var relation in relations.Where(r => r.Item1.Name == "Ali" && r.Item2 == Relationship.Parent))
        //         WriteLine($"Ali has a child called {relation.Item3.Name}");

        // }

        public Research(IRelationshipBrowser browser)
        {
            foreach (var child in browser.FindAllChildrenOf("Ali"))
                WriteLine($"Ali has a child called {child.Name}");
        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "Ali" };
            var child = new Person { Name = "Veli" };
            var child2 = new Person { Name = "Ayşe" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
