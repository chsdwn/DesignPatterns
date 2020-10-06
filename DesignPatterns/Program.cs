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
    public class StringBuilderPlus
    {
        private StringBuilder _builder = new StringBuilder();

        public static implicit operator StringBuilderPlus(string s)
        {
            var stringBuilderPlus = new StringBuilderPlus();
            stringBuilderPlus._builder.Append(s);
            return stringBuilderPlus;
        }

        public static StringBuilderPlus operator +(StringBuilderPlus stringBuilderPlus, string s)
        {
            stringBuilderPlus._builder.Append(s);
            return stringBuilderPlus;
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            StringBuilderPlus message = "hello ";
            message += "world";
            WriteLine(message);
        }
    }
}
