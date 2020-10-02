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
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public static class PointFactory
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

    public class Point
    {
        private double _x, _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"{nameof(_x)}: {_x}, {nameof(_y)} {_y}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var point = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            WriteLine(point);
        }
    }
}
