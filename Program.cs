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
    public class HtmlElement
    {
        private const int INDENT_SIZE = 2;

        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            Name = name;
            Text = text;
        }

        private string ToStringImpl(int indent)
        {
            var stringBuilder = new StringBuilder();
            var i = new string(' ', INDENT_SIZE * indent);
            stringBuilder.AppendLine($"{i}<{Name}>");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                stringBuilder.Append(new string(' ', INDENT_SIZE * (indent + 1)));
                stringBuilder.AppendLine(Text);
            }

            foreach (var element in Elements)
                stringBuilder.Append(element.ToStringImpl(indent + 1));
            stringBuilder.AppendLine($"{i}</{Name}>");

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string _rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            root.Elements.Add(element);
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = _rootName };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var hello = "hello";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<p>");
            stringBuilder.Append(hello);
            stringBuilder.Append("</p>");
            WriteLine(stringBuilder);

            var words = new[] { "hello", "world" };
            stringBuilder.Clear();
            stringBuilder.Append("<ul>");
            foreach (var word in words)
                stringBuilder.AppendFormat("<li>{0}</li>", word);
            stringBuilder.Append("</ul>");
            WriteLine(stringBuilder);

            var htmlBuilder = new HtmlBuilder("ul");
            htmlBuilder.AddChild("li", "hello");
            htmlBuilder.AddChild("li", "world");
            WriteLine(htmlBuilder.ToString());
        }
    }
}
