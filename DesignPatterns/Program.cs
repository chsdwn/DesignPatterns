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
    public class CodeBuilder
    {
        private StringBuilder _builder = new StringBuilder();

        public CodeBuilder Clear()
        {
            _builder.Clear();
            return this;
        }

        public CodeBuilder AppendLine(string? value)
        {
            _builder.AppendLine(value);
            return this;
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
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo")
                .AppendLine("{")
                .AppendLine("}");

            WriteLine(cb);
        }
    }
}
