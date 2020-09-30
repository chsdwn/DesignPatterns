using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using static System.Console;

namespace DesignPatterns
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        // new keyword hides base.Width
        // public new int Width
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Program
    {
        public static int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;

        static void Main(string[] args)
        {
            var rectangle = new Rectangle(2, 3);
            WriteLine($"{rectangle} has area {Area(rectangle)}");

            Rectangle square = new Square();
            square.Width = 4;
            WriteLine($"{square} has area {Area(square)}");
        }
    }
}
