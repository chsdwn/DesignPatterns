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
    public interface IBird
    {
        int Weight { get; set; }
        void Fly();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"Soaring in the sky, weight: {Weight}");
        }
    }

    public interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            WriteLine($"Crawling in the dirt, weight: {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private int _weight;
        private Bird _bird = new Bird();
        private Lizard _lizard = new Lizard();

        public int Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                _bird.Weight = value;
                _lizard.Weight = value;
            }
        }

        public void Fly()
        {
            _bird.Fly();
        }

        public void Crawl()
        {
            _lizard.Crawl();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var dragon = new Dragon();
            dragon.Weight = 120;
            dragon.Fly();
            dragon.Crawl();
        }
    }
}
