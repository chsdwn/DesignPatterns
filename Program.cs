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
    public class Point
    {
        // public static Point Origin => new Point(0, 0);
        public static Point Origin = new Point(0, 0); // better

        private double _x, _y;

        private Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)}: {_x}, {nameof(_y)} {_y}";
        }

        public static class Factory
        {
            public static Point NewCarteshianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);

            var origin = Point.Origin;
            WriteLine(origin);
        }
    }
}
