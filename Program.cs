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
        }
    }
}
