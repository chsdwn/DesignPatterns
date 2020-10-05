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
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"{radius}r circle, vector");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"{radius}r circle, raster");
        }

    }

    public abstract class Shape
    {
        protected IRenderer _renderer;

        protected Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            _renderer.RenderCircle(_radius);
        }

        public override void Resize(float factor)
        {
            _radius *= factor;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            /* --- WITHOUT DEPENDENCY INJECTION --- */
            // var renderer = new RasterRenderer();
            // var renderer = new VectorRenderer();
            // var circle = new Circle(renderer, 5);
            // circle.Draw();
            // circle.Resize(2);
            // circle.Draw();

            /* --- DEPENDENCY INJECTION --- */
            var cb = new ContainerBuilder();
            // when anytime injects IRenderer returns VectorRenderer as singleton
            cb.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();
            cb.Register((componentContext, parameters) =>
                new Circle(componentContext.Resolve<IRenderer>(),
                    parameters.Positional<float>(0))
            );
            using (var container = cb.Build())
            {
                var circle = container.Resolve<Circle>(
                    new PositionalParameter(0, 5f)
                );
                circle.Draw();
                circle.Resize(2f);
                circle.Draw();
            }
        }
    }
}
