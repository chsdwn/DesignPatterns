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
    public interface IShape
    {
        string AsString { get; }
    }

    public class Circle : IShape
    {
        private float _radius;

        public Circle(float radius)
        {
            _radius = radius;
        }

        public void Resize(float factor)
        {
            _radius *= factor;
        }

        public string AsString => $"A circle with radius {_radius}";
    }

    public class Square : IShape
    {
        private float _side;

        public Square(float side)
        {
            _side = side;
        }

        public string AsString => $"A square with side {_side}";
    }

    public class ColoredShape : IShape
    {
        private IShape _shape;
        private string _color;

        public ColoredShape(IShape shape, string color)
        {
            _shape = shape;
            _color = color;
        }

        public string AsString => $"{_shape.AsString} has the color {_color}";
    }

    public class TransparentShape : IShape
    {
        private IShape _shape;
        private float _transparency;

        public TransparentShape(IShape shape, float transparency)
        {
            _shape = shape;
            _transparency = transparency;
        }

        public string AsString => $"{_shape.AsString} has %{_transparency * 100.0} transparency";
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            WriteLine(square.AsString);

            var redSquare = new ColoredShape(square, "Red");
            WriteLine(redSquare.AsString);

            var transparentSquare = new TransparentShape(square, .5f);
            WriteLine(transparentSquare.AsString);
        }
    }
}
