using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using Autofac;
using MoreLinq;
using static System.Console;

namespace DesignPatterns
{
    public class GraphicObject
    {
        public virtual string Name { get; set; } = "Group";
        public string Color;

        private Lazy<List<GraphicObject>> _children = new Lazy<List<GraphicObject>>();
        public List<GraphicObject> Children => _children.Value;

        private void Print(StringBuilder stringBuilder, int depth)
        {
            stringBuilder
                .Append(new string('*', depth))
                .Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : $"{Color} ")
                .AppendLine(Name);

            foreach (var child in Children)
                child.Print(stringBuilder, depth + 1);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            Print(stringBuilder, 0);
            return stringBuilder.ToString();
        }
    }

    public class Circle : GraphicObject
    {
        public override string Name => "Circle";
    }

    public class Square : GraphicObject
    {
        public override string Name => "Square";
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var drawing = new GraphicObject { Name = "Drawing1" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Blue" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Green" });
            group.Children.Add(new Square { Color = "Yello" });
            drawing.Children.Add(group);

            WriteLine(drawing);
        }
    }
}
