using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using static System.Console;

namespace DesignPatterns
{
    public class Document
    {
    }

    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            //
        }

        public void Print(Document document)
        {
            //
        }

        public void Scan(Document document)
        {
            //
        }
    }

    public class OldFashionedPrinter : IMachine
    {
        public void Fax(Document document)
        {
            //
        }

        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter
    {
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter _printer;
        private IScanner _scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }

        public void Print(Document document)
        {
            _printer.Print(document);
        }

        public void Scan(Document document)
        {
            // decorator
            _scanner.Scan(document);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
