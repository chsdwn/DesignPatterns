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

    public class Point
    {
        private double _x, _y;

        /// <summary>
        /// Initializes a point from EITHER cartesian or polar
        /// </summary>
        /// <param name="a">x if cartesian, rho if polar</param>
        /// <param name="b"></param>
        /// <param name="coordinateSystem"></param>
        public Point(double a, double b, CoordinateSystem coordinateSystem = CoordinateSystem.Cartesian)
        {
            switch (coordinateSystem)
            {
                case CoordinateSystem.Cartesian:
                    _x = a;
                    _y = b;
                    break;
                case CoordinateSystem.Polar:
                    _x = a * Math.Cos(b);
                    _y = a * Math.Sin(b);
                    break;
            }
        }

        // public Point(double rho, double theta)
        // {
        //     _x = rho;
        //     _y = theta;
        // }
    }

    public class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
