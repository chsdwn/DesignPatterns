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
    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle() : this(0)
        {
        }

        public Circle(float radius)
        {
            _radius = radius;
        }

        public void Resize(float factor)
        {
            _radius *= factor;
        }

        public override string AsString() => $"A circle with radius {_radius}";
    }

    public class Square : Shape
    {
        private float _side;

        public Square() : this(0)
        {
        }

        public Square(float side)
        {
            _side = side;
        }

        public override string AsString() => $"A square with side {_side}";
    }

    public class ColoredShape : Shape
    {
        private Shape _shape;
        private string _color;

        public ColoredShape(Shape shape, string color)
        {
            _shape = shape;
            _color = color;
        }

        public override string AsString() => $"{_shape.AsString()} has the color {_color}";
    }

    public class TransparentShape : Shape
    {
        private Shape _shape;
        private float _transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            _shape = shape;
            _transparency = transparency;
        }

        public override string AsString() => $"{_shape.AsString()} has %{_transparency * 100.0} transparency";
    }

    public class ColoredShape<T> : Shape
        where T : Shape, new()
    {
        private string _color;

        private T _shape = new T();

        public ColoredShape() : this("black")
        {
        }

        public ColoredShape(string color)
        {
            _color = color;
        }

        public override string AsString() => $"{_shape.AsString()} has the color {_color}";
    }

    public class TransparentShape<T> : Shape
        where T : Shape, new()
    {
        private float _transparency;

        private T _shape = new T();

        public TransparentShape() : this(0)
        {
        }

        public TransparentShape(float transparency)
        {
            _transparency = transparency;
        }

        public override string AsString() => $"{_shape.AsString()} has %{_transparency * 100.0f} transparency";
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var redSquare = new ColoredShape<Square>("red");
            WriteLine(redSquare.AsString());

            var circle = new TransparentShape<ColoredShape<Circle>>(.4f);
            WriteLine(circle.AsString());
        }
    }
}
